using MongoDB.Bson;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using VideoStore.Application.Movies.Interfaces;
using VideoStore.Domain.Movies.Entities;
using VideoStore.Domain.Movies.Repositories;

namespace VideoStore.Application.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<HttpStatusCode> CreateMovieAsync(Movie movie)
        {
            var id = await _movieRepository.InsertAsync(movie);

            if (id == null)
                return HttpStatusCode.InternalServerError;

            return HttpStatusCode.Created;
        }

        public async Task<HttpStatusCode> DeleteMovieAsync(ObjectId id)
        {
            var success = await _movieRepository.RemoveLogicAsync(id);

            if (!success)
                return HttpStatusCode.InternalServerError;

            return HttpStatusCode.OK;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            var movie = await _movieRepository.GetAllAsync();

            return movie;
        }

        public async Task<Movie> GetMovieById(ObjectId id)
        {
            var category = await _movieRepository.GetByIdAsync(id);

            return category;
        }

        public async Task<HttpStatusCode> UpdateMovieAsync(Movie movie)
        {
            var success = await _movieRepository.UpdateAsync(movie);

            if (!success)
                return HttpStatusCode.InternalServerError;

            return HttpStatusCode.OK;
        }
    }
}
