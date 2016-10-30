using itsjustaname_api.Models;
using itsjustaname_api.Modules;

namespace itsjustaname_api.Services.Interfaces
{
    public interface ISummaryService
    {
        SummaryModel GetSummary();
        SummaryModel GetSummary(UserData userData);
    }
}