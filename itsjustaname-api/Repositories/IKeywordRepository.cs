namespace itsjustaname_api.Repositories
{
    public interface IKeywordRepository
    {
        string GetRandomKeyword();
    }

    public class KeywordRepository : IKeywordRepository
    {
        public string GetRandomKeyword()
        {
            return "washing machines";
        }
    }
}