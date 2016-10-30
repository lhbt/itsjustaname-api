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
        public ItemImageSearchRepository()
        {
            var startupPath = AppDomain.CurrentDomain.BaseDirectory;
            ImageUrls = JsonConvert.DeserializeObject(File.ReadAllText(startupPath + "/MockData/imagepaths.json"));
        }

        public dynamic ImageUrls { get; set; }

        public IEnumerable<string> Search(string name)
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