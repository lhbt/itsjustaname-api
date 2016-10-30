using System.Collections.Generic;
using AutoMapper;
using itsjustaname_api.Repositories.Interfaces;
using itsjustaname_api.Services.Interfaces;
using itsjustaname_api.ViewModels;

namespace itsjustaname_api.Services
{
    public class FindAlternativeIncomeService : IFindAlternativeIncomeService
    {
        private readonly IGetDefaultAlternativeIncomeRepository _defaultAlternativeIncomeRepository;
        private readonly IMapper _mapper;

        public FindAlternativeIncomeService(IGetDefaultAlternativeIncomeRepository defaultAlternativeIncomeRepository, IMapper mapper)
        {
            _defaultAlternativeIncomeRepository = defaultAlternativeIncomeRepository;
            _mapper = mapper;
        }

        public IEnumerable<AlternativeIncomeViewModel> GetAll()
        {
            var defaultAlternativeIncome = _defaultAlternativeIncomeRepository.GetAll();

            var resultViewModels = _mapper.Map<IEnumerable<AlternativeIncomeViewModel>>(defaultAlternativeIncome);

            return resultViewModels;
        }
    }
}