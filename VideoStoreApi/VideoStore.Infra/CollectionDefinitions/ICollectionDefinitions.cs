using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using VideoStore.Domain.Models;

namespace VideoStore.Infra.CollectionDefinitions
{
    public interface ICollectionDefinitions<TEntity> where TEntity : Entity<ObjectId>
    {
        IMongoCollection<TEntity> GetCollection(IMongoDatabase database);
    }
}
