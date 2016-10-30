using AutoMapper;
using itsjustaname_api.Models;
using itsjustaname_api.Repositories.Interfaces;
using itsjustaname_api.Services.Interfaces;

namespace itsjustaname_api.Services
{
    public class SpendService : ISpendService
    {
        private readonly IEbayService _ebayService;
        private readonly IKeywordRepository _keywordsRepository;
        private readonly IMapper _mapper;

        public SpendService(IKeywordRepository keywordsRepository, IEbayService ebayService, IMapper mapper)
        {
            _keywordsRepository = keywordsRepository;
            _ebayService = ebayService;
            _mapper = mapper;
        }

        public SpendModel GetRandomIdea()
        {
            var keyword = _keywordsRepository.GetRandomKeyword();

            var ebayProduct = _ebayService.GetEbayProduct(keyword);

            var result = _mapper.Map<SpendModel>(ebayProduct);

            return result;
        }
    }
}