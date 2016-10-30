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

        private readonly IDictionary<string, string> ImageMemoryCache; 

        public ItemImageSearchRepository()
        {
            ImageMemoryCache = new Dictionary<string,string>();
            _imageCache = new ImageCacheRepository();
            var startupPath = AppDomain.CurrentDomain.BaseDirectory;
            ImageUrls = JsonConvert.DeserializeObject(File.ReadAllText(startupPath + "/MockData/imagepaths.json"));
        }

        public dynamic ImageUrls { get; set; }

        public IEnumerable<string> Search(string name)
        {
            if (ImageMemoryCache.ContainsKey(name))
            {
                return new List<string> {ImageMemoryCache[name]};
            }
            else
            {
                var localCacheSearchResult = SearchLocalCache(name);
                if (localCacheSearchResult.Any())
                {
                    ImageMemoryCache.Add(name, localCacheSearchResult.First());
                    return localCacheSearchResult;
                }

                var searchLocalStore = SearchLocalStore(name);
                if (searchLocalStore.Any())
                {
                    ImageMemoryCache.Add(name, searchLocalStore.First());
                }
                return searchLocalStore;
            }

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