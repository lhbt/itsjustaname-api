using System.Collections.Generic;
using itsjustaname_api.Models;

namespace itsjustaname_api.Repositories.Interfaces
{
    public interface IAssetRepository
    {
        IEnumerable<AssetModel> GetAll();
    }
}