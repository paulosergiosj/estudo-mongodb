using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net;
using System.Threading.Tasks;
using VideoStore.Application.Movies.Interfaces;
using VideoStore.Domain.Movies.Contracts;
using VideoStore.Domain.Movies.Entities;

namespace VideoStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMovieMapper _movieMapper;

        public MovieController(IMovieService movieService, IMovieMapper movieMapper)
        {
            _movieService = movieService;
            _movieMapper = movieMapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieDto movie)
        {
            var map = _movieMapper.MapDtoToObjectResultEntity(movie);
            if (map.StatusCode == (int)HttpStatusCode.InternalServerError)
                return map;

            return await _movieService.CreateMovieAsync((Movie)map.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieService.GetAllMoviesAsync();

            return _movieMapper.MapEntitiesToDtoObjectResult(movies);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromBody] MovieDto movie)
        {
            var map = _movieMapper.MapDtoToObjectResultEntity(movie);
            if (map.StatusCode == (int)HttpStatusCode.InternalServerError)
                return map;

            return await _movieService.UpdateMovieAsync((Movie)map.Value);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return await _movieService.GetMovieById(ObjectId.Parse(id));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove([FromRoute] string id)
        {
            return new JsonResult(await _movieService.DeleteMovieAsync(ObjectId.Parse(id)));
        }

    }
}
