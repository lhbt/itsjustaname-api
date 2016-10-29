using System.Threading.Tasks;
using itsjustaname_api.Models;
using itsjustaname_api.Repositories;

namespace itsjustaname_api.Services
{
    public class SpendService : ISpendService
    {
        private readonly IKeywordRepository _keywordsRepository;
        private readonly IEbayService _ebayService;

        public SpendService(IKeywordRepository keywordsRepository, IEbayService ebayService)
        {
            _keywordsRepository = keywordsRepository;
            _ebayService = ebayService;
        }

        public SpendModel GetRandomIdea()
        {
            var keyword = _keywordsRepository.GetRandomKeyword();

            var ebayProduct = _ebayService.GetEbayProduct(keyword);
            
            return new SpendModel
            {
                ImageUrl = ebayProduct.ImageUrl,
                Price = ebayProduct.Price,
                Name = ebayProduct.Name,
                LinkToArticle = ebayProduct.ItemUrl
            };
        }
    }
}