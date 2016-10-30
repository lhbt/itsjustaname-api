using itsjustaname_api.Models;

namespace itsjustaname_api.Services.Interfaces
{
    public interface IEbayService
    {
        EbayProductModel GetEbayProduct(string keyword);
    }
}