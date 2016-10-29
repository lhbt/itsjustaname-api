using itsjustaname_api.Services;
using Nancy;

namespace itsjustaname_api
{
    public class UpgradeSpendingModule : NancyModule
    {
        public UpgradeSpendingModule(IUpgradeSpendingService upgradeSpendingService)
        {
            Get["/upgrade/{name}"] = parameters =>
            {
                string itemName = parameters.name;
                var upgrades = upgradeSpendingService.FindUpgrade(itemName); 
                return Response.AsJson(upgrades);
            };
        }
    }
}