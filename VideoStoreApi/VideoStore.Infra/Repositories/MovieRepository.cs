using MongoDB.Driver;
using VideoStore.Domain.Movies.Entities;
using VideoStore.Domain.Movies.Repositories;

namespace VideoStore.Infra.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(IMongoClient client)
            : base(client) { }
    }
}
