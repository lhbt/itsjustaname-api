using itsjustaname_api.Models;
using itsjustaname_api.Repositories;

namespace itsjustaname_api.Services
{
    public class SpendService : ISpendService
    {
        private readonly IKeywordRepository _keywordsRepository;

        public SpendService(IKeywordRepository keywordsRepository)
        {
            _keywordsRepository = keywordsRepository;
        }

        public SpendModel GetRandomIdea()
        {
            var keyword = _keywordsRepository.GetRandomKeyword();
            
            return new SpendModel
            {
                ImageUrl = "http://thumbs4.ebaystatic.com/m/m-t38kJKKUVaDGi309wo2JA/140.jpg",
                Price = 219.99,
                Name = "Beko WMB61432B Free Standing 6Kg 1400 Spin Slim Depth Washing Machine - Black",
                LinkToArticle = "http://www.ebay.co.uk/itm/Beko-WMB61432B-Free-Standing-6Kg-1400-Spin-Slim-Depth-Washing-Machine-Black-/361504943331"
            };
        }
    }
}