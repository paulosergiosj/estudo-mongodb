using MongoDB.Bson.Serialization.Attributes;

namespace VideoStore.Domain.Models
{
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        [BsonId]
        public TPrimaryKey Id { get; set; }

        public bool Removed { get; set; }
    }
}
