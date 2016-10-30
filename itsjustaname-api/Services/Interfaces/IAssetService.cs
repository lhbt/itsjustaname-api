using System.Collections.Generic;
using itsjustaname_api.ViewModels;

namespace itsjustaname_api.Services.Interfaces
{
    public interface IAssetService
    {
        IEnumerable<AssetViewModel> GetAll();
    }
}