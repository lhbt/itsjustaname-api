using itsjustaname_api.Services;
using itsjustaname_api.Services.Interfaces;
using Nancy;

namespace itsjustaname_api
{
    public class ItemImageModule : NancyModule
    {
        public ItemImageModule(IItemImageSearchService itemImageSearchService)
        {
            Get["/itemimage/{name}"] = parameters =>
            {
                string name = parameters.name;
                var imageUrl = itemImageSearchService.SearchImage(name);

                return Response.AsJson(imageUrl);
            };
        }
    }
}