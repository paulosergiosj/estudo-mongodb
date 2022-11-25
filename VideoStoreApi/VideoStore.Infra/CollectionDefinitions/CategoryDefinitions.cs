using MongoDB.Driver;
using System.Linq;
using VideoStore.Domain.Categories.Entities;

namespace VideoStore.Infra.CollectionDefinitions
{
    public class CategoryDefinitions : ICollectionDefinitions<Category>
    {
        public IMongoCollection<Category> GetCollection(IMongoDatabase database)
        {
            var coll = database.GetCollection<Category>(typeof(Category).Name);

            var hasIndexes = coll.Indexes.List().ToList().Count();
            if (hasIndexes <= 1)
            {
                var indexBuilder = Builders<Category>.IndexKeys;
                var keys = indexBuilder.Ascending(category => category.Description);
                var options = new CreateIndexOptions
                {
                    Background = true,
                    Unique = true
                };
                var indexModel = new CreateIndexModel<Category>(keys, options);
                coll.Indexes.CreateOne(indexModel);
            }

            return coll;
        }
    }
}
