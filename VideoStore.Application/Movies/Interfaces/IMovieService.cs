using MongoDB.Bson;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using VideoStore.Domain.Movies.Entities;

namespace VideoStore.Application.Movies.Interfaces
{
    public interface IMovieService
    {
        Task<HttpStatusCode> CreateMovieAsync(Movie movie);
        Task<HttpStatusCode> DeleteMovieAsync(ObjectId id);
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieById(ObjectId id);
        Task<HttpStatusCode> UpdateMovieAsync(Movie movie);
    }
}