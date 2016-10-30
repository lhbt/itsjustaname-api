using System;
using System.Runtime.Caching;

namespace itsjustaname_api.Repositories
{
    public class ImageCacheRepository
    {
        public ImageCacheRepository()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "/imagecache/";
            _imageStore = new FileCache(path);
        }

        private readonly FileCache _imageStore;

        public string GetImage(string name)
        {
            try
            {
                if (_imageStore.Contains(name))
                {
                    return (string) _imageStore.Get(name);
                }
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }
    }
}