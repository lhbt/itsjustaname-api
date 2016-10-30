using System;
using System.Collections.Generic;
using System.IO;
using itsjustaname_api.Models;
using itsjustaname_api.Repositories.Interfaces;
using Newtonsoft.Json;

namespace itsjustaname_api.Repositories
{
    public class DefaultAlternativeIncomeRepository :IGetDefaultAlternativeIncomeRepository
    {
        public DefaultAlternativeIncomeRepository()
        {
            defaultAlternativeIncome = GetAlternativeModelsFromFile();
        }

        private IEnumerable<AlternativeIncomeModel> GetAlternativeModelsFromFile()
        {
            var startupPath = AppDomain.CurrentDomain.BaseDirectory;
            var result = JsonConvert.DeserializeObject<AlternativeIncomeModel[]>(File.ReadAllText(startupPath + "/MockData/defaultalternativeincome.json"));
            return result;
        }

        private readonly IEnumerable<AlternativeIncomeModel> defaultAlternativeIncome;

        public IEnumerable<AlternativeIncomeModel> GetAll()
        {
            return defaultAlternativeIncome;
        }
    }
}