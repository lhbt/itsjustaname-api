using System.Collections.Generic;

namespace itsjustaname_api.Repositories
{
    public interface IItemImageSearchRepository
    {
        IEnumerable<string> Search(string name);
    }
}