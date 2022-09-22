using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VideoStore.Application.Categories.Services;
using VideoStore.Application.Movies.Interfaces;
using VideoStore.Domain.Movies.Entities;
using VideoStore.Domain.Movies.Repositories;

namespace VideoStore.Application.Movies.Services
{
    public class MovieService : IMovieService
    {
        public const string ERROR_INVALID_CATEGORY = "Category(s) invalid";
        public const string ERROR_MOVIE_NON_CREATED = "Movie could not be created";
        public const string ERROR_MOVIE_COULD_NOT_BE_UPDATED = "Movie could not be updated";

        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryValidator _categoryValidator;

        public MovieService(IMovieRepository movieRepository, ICategoryValidator categoryValidator)
        {
            _movieRepository = movieRepository;
            _categoryValidator = categoryValidator;
        }

        public async Task<ObjectResult> CreateMovieAsync(Movie movie)
        {
            if (!await _categoryValidator.IsCategoriesIdvalid(movie.CategoriesId.Select(x => (ObjectId)x.Id)))
                return GetBadRequestObjectResult(ERROR_INVALID_CATEGORY);

            var id = await _movieRepository.InsertAsync(movie);

            if (id == null)
                return GetBadRequestObjectResult(ERROR_MOVIE_NON_CREATED);

            return new ObjectResult(HttpStatusCode.Created);
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
            var movies = await _movieRepository.GetAllAsync();

            return movies;
        }

        public async Task<ObjectResult> GetMovieById(ObjectId id)
        {
            var category = await _movieRepository.GetByIdAsync(id);

            return new ObjectResult(category);
        }

        public async Task<ObjectResult> UpdateMovieAsync(Movie movie)
        {
            if (!await _categoryValidator.IsCategoriesIdvalid(movie.CategoriesId.Select(x => (ObjectId)x.Id)))
                return GetBadRequestObjectResult(ERROR_INVALID_CATEGORY);

            var success = await _movieRepository.UpdateAsync(movie);

            if (!success)
                return GetBadRequestObjectResult(ERROR_MOVIE_COULD_NOT_BE_UPDATED);

            return new ObjectResult(HttpStatusCode.Created);
        }

        private BadRequestObjectResult GetBadRequestObjectResult(string message)
        {
            return new BadRequestObjectResult(new Exception(message));
        }
    }
}
