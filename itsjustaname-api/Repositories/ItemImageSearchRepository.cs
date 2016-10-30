using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using itsjustaname_api.Repositories.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace itsjustaname_api.Repositories
{
    public class ItemImageSearchRepository : IItemImageSearchRepository
    {
        private readonly ImageCacheRepository _imageCache;

        private readonly IDictionary<string, string> _imageMemoryCache; 

        public ItemImageSearchRepository()
        {
            _imageMemoryCache = new Dictionary<string,string>();
            _imageCache = new ImageCacheRepository();
            var startupPath = AppDomain.CurrentDomain.BaseDirectory;
            ImageUrls = JsonConvert.DeserializeObject(File.ReadAllText(startupPath + "/MockData/imagepaths.json"));
        }

        public dynamic ImageUrls { get; set; }

        public IEnumerable<string> Search(string name)
        {
            if (_imageMemoryCache.ContainsKey(name))
            {
                return new List<string> {_imageMemoryCache[name]};
            }
            else
            {
                var searchOtherStoresResult = SearchOtherStores(name);
                if (!_imageMemoryCache.ContainsKey(name) && searchOtherStoresResult.Any())
                {
                    _imageMemoryCache.Add(name, searchOtherStoresResult.First());
                }
                return searchOtherStoresResult;
            }
        }

        private IEnumerable<string> SearchOtherStores(string name)
        {
            var localCacheSearchResult = SearchLocalCache(name);
            if (localCacheSearchResult.Any())
            {
                return localCacheSearchResult;
            }

            var searchLocalStore = SearchLocalStore(name);
            return searchLocalStore;
        }

        private IEnumerable<string> SearchLocalCache(string name)
        {
            var result = _imageCache.GetImage(name);
            if (result != string.Empty)
            {
                return new List<string>() {result};
            }
            return new List<string>();
        }

        private IEnumerable<string> SearchLocalStore(string name)
        {
            try
            {
                JArray serialisedValue = ImageUrls[name];
                var urls = serialisedValue.Select(u => (string) u);
                return urls;
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }
    }
}