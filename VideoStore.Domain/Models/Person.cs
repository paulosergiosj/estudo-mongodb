using MongoDB.Bson;
using System;
using VideoStore.Domain.Models.Enums;

namespace VideoStore.Domain.Models
{
    public abstract class Person : Entity<ObjectId>
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
    }
}
