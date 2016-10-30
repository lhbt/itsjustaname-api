using System;
using System.Collections.Generic;
using System.Linq;
using itsjustaname_api;
using itsjustaname_api.ViewModels;
using Nancy.Testing;

namespace ImageCache
{
    public class Program
    {
        public static void Main()
        {
            var browser = new Browser(new Bootstrapper());
            var transactions = browser.Get("/transactions").Body.DeserializeJson< IEnumerable < DailyTransactionBlockViewModel >> ();
            var namesForImageQUery = transactions.SelectMany(x => x.Transactions.Select(y => y.Name));
            var imageRepository = new ImageRepository();
            var imageUrlList = new List<string>();
            foreach (var name in namesForImageQUery)
            {
                var imageUrl = imageRepository.GetImage(name);
                imageUrlList.Add(imageUrl);
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}