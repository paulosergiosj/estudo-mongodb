using MongoDB.Bson;
using VideoStore.Domain.Models;

namespace VideoStore.Domain.Categories.Entities
{
    public class Category : Entity<ObjectId>
    {
        public string Description { get; set; }

    }
}
