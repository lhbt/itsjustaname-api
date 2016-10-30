using System.Collections.Generic;
using AutoMapper;
using itsjustaname_api.Repositories.Interfaces;
using itsjustaname_api.ViewModels;

namespace itsjustaname_api.Services.Interfaces
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IMapper _mapper;

        public AssetService(IAssetRepository assetRepository, IMapper mapper)
        {
            _assetRepository = assetRepository;
            _mapper = mapper;
        }

        public IEnumerable<AssetViewModel> GetAll()
        {
            var assetModels = _assetRepository.GetAll();
            var result = _mapper.Map<IEnumerable<AssetViewModel>>(assetModels);
            return result;
        }
    }
}