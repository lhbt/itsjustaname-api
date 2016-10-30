using itsjustaname_api.Services.Interfaces;
using Nancy;

namespace itsjustaname_api.Modules
{
    public class AlternativeIncomeModule : NancyModule
    {
        public AlternativeIncomeModule(IFindAlternativeIncomeService findAlternativeIncomeService)
        {
            Get["/alternativeincome"] = _ => Response.AsJson(findAlternativeIncomeService.GetAll());
        }
    }
}