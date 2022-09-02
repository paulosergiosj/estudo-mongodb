using MongoDB.Bson;
using System.Collections.Generic;
using VideoStore.Domain.Categories.Entities;
using VideoStore.Domain.Models;

namespace VideoStore.Domain.Movies.Entities
{
    public class Movie : Entity<ObjectId>
    {
        public string Title { get; set; }
        public string DirectorName { get; set; }
        public List<Category> Categories { get; set; }
    }
}
