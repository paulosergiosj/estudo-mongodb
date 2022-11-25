using VideoStore.Application.Movies.Interfaces;
using VideoStore.Domain.Base;
using VideoStore.Domain.Movies.Entities;

namespace VideoStore.Application.Movies.Services
{
    public class MovieServiceBuilder : ServiceBuilderBase<Movie>, IMovieServiceBuilder
    {
    }
}
