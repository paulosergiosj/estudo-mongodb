using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Threading.Tasks;
using VideoStore.Application.Movies.Interfaces;
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
        public async Task<IActionResult> Create(MovieCommand movie)
        {
            var response = await _movieService.CreateMovieAsync(movie.SetOperation(Operation.Insert));

            Response.StatusCode = (int)response.StatusCode;

            return new JsonResult(response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _movieService.GetAllMovies();

            Response.StatusCode = (int)response.StatusCode;

            return new JsonResult(response);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromBody] MovieCommand movie)
        {
            var response = await _movieService.UpdateMovieAsync(movie.SetOperation(Operation.Update));

            Response.StatusCode = (int)response.StatusCode;

            return new JsonResult(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            var response = _movieService.GetMovieById(ObjectId.Parse(id));

            Response.StatusCode = (int)response.StatusCode;

            return new JsonResult(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove([FromRoute] string id)
        {
            var response = await _movieService.DeleteMovieAsync(ObjectId.Parse(id));

            Response.StatusCode = (int)response.StatusCode;

            return new JsonResult(response);
        }

    }
}
