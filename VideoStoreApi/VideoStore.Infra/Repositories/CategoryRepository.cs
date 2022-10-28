using MongoDB.Driver;
using VideoStore.Domain.Categories.Entities;
using VideoStore.Domain.Categories.Repositories;

namespace VideoStore.Infra.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IMongoClient client)
            : base(client) { }
    }
}
