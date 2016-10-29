namespace itsjustaname_api.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public string GetAll()
        {
            return string.Empty;
        }
    }

    public interface ITransactionRepository
    {
        string GetAll();
    }
}