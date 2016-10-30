using System;
using System.Runtime.Caching;

namespace itsjustaname_api.Repositories
{
    public class ImageCacheRepository
    {
        public ImageCacheRepository()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "/imagecache/";
            ImageStore = new FileCache(path);
        }

        private FileCache ImageStore { get; }

        public string GetImage(string name)
        {
            if (ImageStore.Contains(name))
            {
                return (string)ImageStore.Get(name);
            }
            return string.Empty;
        }
    }
}