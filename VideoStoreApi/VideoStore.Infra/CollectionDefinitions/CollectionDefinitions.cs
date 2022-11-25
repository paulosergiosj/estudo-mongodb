using MongoDB.Bson;
using MongoDB.Driver;
using VideoStore.Domain.Models;

namespace VideoStore.Infra.CollectionDefinitions
{
    public abstract class CollectionDefinitions<TEntity> : ICollectionDefinitions<TEntity> where TEntity : Entity<ObjectId>
    {
        public abstract IMongoCollection<TEntity> GetCollection(IMongoDatabase database);
    }
}
