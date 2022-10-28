using VideoStore.Domain.Base;
using VideoStore.Domain.Movies.Entities;

namespace VideoStore.Domain.Movies.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
    }
}
