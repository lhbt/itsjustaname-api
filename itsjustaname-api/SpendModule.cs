using itsjustaname_api.Services;
using Nancy;

namespace itsjustaname_api
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