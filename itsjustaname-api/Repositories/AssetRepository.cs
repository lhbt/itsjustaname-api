using System;
using System.Collections.Generic;
using System.IO;
using itsjustaname_api.Models;
using itsjustaname_api.Repositories.Interfaces;
using Newtonsoft.Json;

namespace itsjustaname_api.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private IEnumerable<AssetModel> _assetsStore;

        public AssetRepository()
        {
            GetDefaultAssets();
        }

        private void GetDefaultAssets()
        {
            var startupPath = AppDomain.CurrentDomain.BaseDirectory;
            _assetsStore = JsonConvert.DeserializeObject<AssetModel[]>(File.ReadAllText(startupPath + "/MockData/assets.json"));
        }

        public IEnumerable<AssetModel> GetAll()
        {
            return _assetsStore;
        }
    }
}