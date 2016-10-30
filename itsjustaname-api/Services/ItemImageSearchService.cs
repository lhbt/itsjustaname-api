using System.Linq;
using itsjustaname_api.Repositories;

namespace itsjustaname_api.Services
{
    public class ItemImageSearchService : IItemImageSearchService
    {
        private readonly IItemImageSearchRepository _repository;

        public ItemImageSearchService(IItemImageSearchRepository repository)
        {
            _repository = repository;
        }

        public string SearchImage(string name)
        {
            var results = _repository.Search(name.ToLower());

            return results.FirstOrDefault();
        }
    }
}