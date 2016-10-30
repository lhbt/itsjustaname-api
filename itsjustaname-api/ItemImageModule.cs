using itsjustaname_api.Services;
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
                var imageUrl = itemImageSearchService.SearchImage(name.ToLower());

                return Response.AsJson(imageUrl);
            };
        }
    }
}