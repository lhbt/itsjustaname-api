using itsjustaname_api.Services.Interfaces;
using Nancy;

namespace itsjustaname_api.Modules
{
    public class AssetsModule : NancyModule
    {
        public AssetsModule(IAssetService assetService)
        {
            Get["/assets"] = _ =>
            {
                var assets = assetService.GetAll();
                return Response.AsJson(assets);
            };
        }
    }
}