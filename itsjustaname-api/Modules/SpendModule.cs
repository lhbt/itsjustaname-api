using itsjustaname_api.Services.Interfaces;
using Nancy;

namespace itsjustaname_api.Modules
{
    public class SpendModule : NancyModule
    {
        public SpendModule(ISpendService spendService)
        {
            Get["/spend"] = _ =>
            {
                var spendIdea = spendService.GetRandomIdea();
                return Response.AsJson(spendIdea);
            };
        }
    }
}