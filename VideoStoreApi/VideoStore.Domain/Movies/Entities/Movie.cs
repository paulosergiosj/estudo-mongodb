using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using VideoStore.Domain.Categories.Entities;
using VideoStore.Domain.Models;

namespace VideoStore.Domain.Movies.Entities
{
    public class Movie : Entity<ObjectId>
    {
        public string Title { get; private set; }
        public string DirectorName { get; private set; }
        public string Synopsis { get; set; }

        public decimal Rate { get; set; }
        public List<MongoDBRef> CategoriesId { get; private set; }
        public DateTime ReleaseDate { get; set; }

        public Movie(string title, string directorName, string synopsis, decimal rate, DateTime releaseDate)
        {
            Title = title;
            DirectorName = directorName;
            Synopsis = synopsis;
            Rate = rate;
            ReleaseDate = releaseDate;
            CategoriesId = new List<MongoDBRef>();
        }

        public Movie(string id, string title, string directorName, string synopsis, decimal rate, DateTime releaseDate)
        {
            Id = ObjectId.Parse(id);
            Title = title;
            DirectorName = directorName;
            Synopsis = synopsis;
            Rate = rate;
            ReleaseDate = releaseDate;
            CategoriesId = new List<MongoDBRef>();
        }

        public Movie AddCategory(ObjectId categoryId)
        {
            CategoriesId.Add(new MongoDBRef(nameof(Category), categoryId));
            return this;
        }

        public Movie AddCategories(IEnumerable<string> categoriesId)
        {
            CategoriesId.AddRange(
                categoriesId.Select(x => new MongoDBRef(nameof(Category), ObjectId.Parse(x))));
            return this;
        }
    }
}
