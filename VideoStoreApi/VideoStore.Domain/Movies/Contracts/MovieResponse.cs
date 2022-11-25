using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStore.Domain.Movies.Contracts
{
    public class MovieResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string DirectorName { get;  set; }
        public string Synopsis { get; set; }
        public decimal Rate { get; set; }
        public List<string> CategoriesId { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
