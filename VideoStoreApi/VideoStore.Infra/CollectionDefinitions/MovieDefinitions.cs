using MongoDB.Driver;
using System.Linq;
using VideoStore.Domain.Movies.Entities;

namespace VideoStore.Infra.CollectionDefinitions
{
    public class MovieDefinitions : ICollectionDefinitions<Movie>
    {
        public IMongoCollection<Movie> GetCollection(IMongoDatabase database)
        {
            var coll = database.GetCollection<Movie>(typeof(Movie).Name);

            var hasIndexes = coll.Indexes.List().ToList().Count();
            if (hasIndexes <= 1)
            {
                var indexBuilder = Builders<Movie>.IndexKeys;
                var keys = indexBuilder
                    .Ascending(movie => movie.Title)
                    .Ascending(movie => movie.DirectorName);
                var options = new CreateIndexOptions
                {
                    Background = true,
                    Unique = true
                };
                var indexModel = new CreateIndexModel<Movie>(keys, options);
                coll.Indexes.CreateOne(indexModel);
            }

            return coll;
        }
    }
}
