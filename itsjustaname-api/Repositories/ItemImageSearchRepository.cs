using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using DuckDuckGo.Net;

namespace itsjustaname_api.Repositories
{
    public class ItemImageSearchRepository : IItemImageSearchRepository
    {
        private readonly FileCache _cache;
        private const string TeamName = "hackmanchester2016-itsjustaname-team";

        public ItemImageSearchRepository()
        {
            _cache = new FileCache(AppDomain.CurrentDomain.BaseDirectory + "filecache");
        }

        public IEnumerable<string> Search(string name)
        {
            var cachedItem = _cache.Get(name);
            if (cachedItem != null)
            {
                return (IEnumerable<string>)cachedItem;
            }

            try
            {
                var search = new Search();
                var images = search.Query(name, "random2");
                
                if (images.Results.Any())
                {
                    var iconUrls = images.Results.Select(i => i.Icon.Url);
                    _cache.Add(name, iconUrls, DateTimeOffset.MaxValue);
                    return iconUrls;
                }
            }
            catch (Exception e)
            {
                return new List<string>();
            }

            return new List<string>();
        }
    }
}