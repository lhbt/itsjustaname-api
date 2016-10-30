using itsjustaname_api.Models;

namespace itsjustaname_api.Services
{
    public interface ISummaryService
    {
        SummaryModel GetSummary();
        SummaryModel GetSummary(UserData userData);
    }
}