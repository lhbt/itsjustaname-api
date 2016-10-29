using System;
using System.Collections.Generic;
using System.Linq;

namespace itsjustaname_api.Repositories
{
    public class KeywordRepository : IKeywordRepository
    {
        public string GetRandomKeyword()
        {
            var keywords = new List<string>
            {
                "washing machines",
                "consoles",
                "gardening",
                "baby clothes",
                "pets",
                "deep frying",
                "coffee",
                "diy",
                "board games",
                "books",
                "movies",
                "princess",
                "cucumber",
                "toilet",
                "medicine",
                "pool",
                "table football",
                "stadium",
                "house",
                "hotel",
                "kitchen",
                "car",
                "computer",
                "jewelry"
            };

            var rnd = new Random();
            var r = rnd.Next(keywords.Count);
            return keywords[r];
        }
    }
}