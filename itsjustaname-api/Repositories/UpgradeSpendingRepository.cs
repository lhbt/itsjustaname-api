using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using itsjustaname_api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace itsjustaname_api.Repositories
{
    public class UpgradeSpendingRepository : IUpgradeSpendingRepository
    {
        public UpgradeSpendingRepository()
        {
            var startupPath = AppDomain.CurrentDomain.BaseDirectory;
            UpgradeSpendings = JsonConvert.DeserializeObject(File.ReadAllText(startupPath + "/MockData/upgradespending.json"));
        }

        public dynamic UpgradeSpendings { get; set; }

        public IEnumerable<UpgradeModel> GetUpgrades(string name)
        {
            try
            {
                JArray results = UpgradeSpendings[name];
                var resultsAsStrings = results.Select(r => r.ToString());
                var models = resultsAsStrings.Select(JsonConvert.DeserializeObject<UpgradeModel>);
                return models;
            }
            catch (Exception)
            {
                return new List<UpgradeModel>();
            }
        }
    }
}