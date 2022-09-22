using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace VideoStore.Domain.Movies.Contracts
{
    public class MovieDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string DirectorName { get; set; }
        public string Synopsis { get; set; }
        public decimal Rate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<string> Categories { get; set; }
    }
}
