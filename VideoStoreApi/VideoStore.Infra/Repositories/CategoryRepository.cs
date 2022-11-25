using MongoDB.Driver;
using VideoStore.Domain.Categories.Entities;
using VideoStore.Domain.Categories.Repositories;
using VideoStore.Infra.CollectionDefinitions;

namespace VideoStore.Infra.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IMongoClient client, ICollectionDefinitions<Category> collectionDefinitions)
            : base(client, collectionDefinitions) { }
    }
}
