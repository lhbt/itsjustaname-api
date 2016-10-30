using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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
            var serialisedValue = ImageUrls[name];
            var urls = JsonConvert.DeserializeObject<IEnumerable<string>>(serialisedValue);
            return new List<string>();
        }
    }
}