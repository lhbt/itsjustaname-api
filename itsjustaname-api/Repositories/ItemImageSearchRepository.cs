using System.Collections.Generic;
using System.Linq;
using Google.Apis.Customsearch.v1;
using Google.Apis.Services;

namespace itsjustaname_api.Repositories
{
    public class ItemImageSearchRepository : IItemImageSearchRepository
    {
        private const string SearchEngineId = "009601827502395592011:szcyrtnqdwi";
        private const string ApiKey = "AIzaSyDYAMUgs56LqEcmAb1w7WVs0I_6zqv1HL8";


        public ItemImageSearchRepository()
        {
            _searchEngine = new CustomsearchService(new BaseClientService.Initializer() { ApiKey = ApiKey });
        }

        private readonly CustomsearchService _searchEngine;

        public IEnumerable<string> Search(string name)
        {
            var listRequest = _searchEngine.Cse.List(name);
            listRequest.Cx = SearchEngineId;
            listRequest.SearchType = CseResource.ListRequest.SearchTypeEnum.Image;
            var queryResult = listRequest.Execute();
            if (queryResult.Items != null)
            {
                var links = queryResult.Items.Select(r => r.Link);
                return links;
            }

            return new List<string>();
        }
    }
}