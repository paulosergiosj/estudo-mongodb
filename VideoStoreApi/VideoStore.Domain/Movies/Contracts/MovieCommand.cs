using MongoDB.Bson;
using System;
using System.Collections.Generic;
using VideoStore.Domain.Base;
using VideoStore.Domain.Models.Enums;

namespace VideoStore.Domain.Movies.Contracts
{
    public class MovieCommand : CommandBase
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string DirectorName { get; set; }
        public string Synopsis { get; set; }
        public decimal Rate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<string> Categories { get; set; }

        public MovieCommand SetOperation(Operation operation)
        {
            Operation = operation;
            return this;
        }
    }
}
