using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Threading.Tasks;
using VideoStore.Application.Movies.Interfaces;
using VideoStore.Domain.Base;
using VideoStore.Domain.Models.Enums;
using VideoStore.Domain.Movies.Contracts;

namespace VideoStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public async Task<Result> Create(MovieCommand movie)
        {
            return await _movieService.CreateMovieAsync(movie.SetOperation(Operation.Insert));
        }

        [HttpGet]
        public async Task<Result> GetAll()
        {
            return await _movieService.GetAllMoviesAsync();
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<Result> Update([FromBody] MovieCommand movie)
        {
            return await _movieService.UpdateMovieAsync(movie.SetOperation(Operation.Update));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Result> GetById([FromRoute] string id)
        {
            return await _movieService.GetMovieByIdASync(ObjectId.Parse(id));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<Result> Remove([FromRoute] string id)
        {
            return await _movieService.DeleteMovieAsync(ObjectId.Parse(id));
        }

    }
}
