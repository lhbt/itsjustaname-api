using System.Collections.Generic;

namespace itsjustaname_api.Repositories.Interfaces
{
    public interface IItemImageSearchRepository
    {
        IEnumerable<string> Search(string name);
    }
}