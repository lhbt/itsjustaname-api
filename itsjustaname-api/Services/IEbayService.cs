using System.Threading.Tasks;
using itsjustaname_api.Models;

namespace itsjustaname_api.Services
{
    public interface IEbayService
    {
        EbayProductModel GetEbayProduct(string keyword);
    }
}