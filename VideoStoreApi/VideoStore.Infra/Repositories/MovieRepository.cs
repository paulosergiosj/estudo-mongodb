using MongoDB.Driver;
using VideoStore.Domain.Movies.Entities;
using VideoStore.Domain.Movies.Repositories;
using VideoStore.Infra.CollectionDefinitions;

namespace VideoStore.Infra.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(IMongoClient client, ICollectionDefinitions<Movie> collectionDefinitions)
            : base(client, collectionDefinitions) { }
    }
}
