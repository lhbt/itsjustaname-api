using System;
using System.Net.Http;
using itsjustaname_api.Models;
using itsjustaname_api.Models.EbayModels;
using Newtonsoft.Json;

namespace itsjustaname_api.Services
{
    public class EbayService : IEbayService
    {
        public EbayProductModel GetEbayProduct(string keyword)
        {
            var ebayRequestUrl =
                $"http://svcs.ebay.com/services/search/FindingService/v1?OPERATION-NAME=findItemsByKeywords&GLOBAL-ID=EBAY-GB&SERVICE-VERSION=1.0.0&SECURITY-APPNAME=LaurentH-itsjusta-PRD-1bff3fe44-a2999161&RESPONSE-DATA-FORMAT=JSON&REST-PAYLOAD&keywords={keyword}&paginationInput.entriesPerPage=10";
            
            var client = new HttpClient();
            var jsonResponse = client.GetStringAsync(new Uri(ebayRequestUrl)).Result;

            var ebayResponse = JsonConvert.DeserializeObject<EbayResponse>(jsonResponse);
            
            var ebaySearchResult = ebayResponse.ResponseItems[0].SearchResult[0];

            var random = new Random();
            var itemAtRandom = random.Next(ebaySearchResult.Items.Length);
            
            var ebayItem = ebaySearchResult.Items[itemAtRandom];

            var name = ebayItem.Name[0];
            var imageUrl = ebayItem.ImageUrl[0];
            var itemUrl = ebayItem.ItemUrl[0];
            var price = ebayItem.Prices[0].ConvertedPrice[0].Value;
            
            return new EbayProductModel
            {
                Name = name,
                Price = price,
                ImageUrl = imageUrl,
                ItemUrl = itemUrl
            };
        }
    }
}