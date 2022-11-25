using MongoDB.Bson;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VideoStore.Application.Helpers;
using VideoStore.Application.Movies.Interfaces;
using VideoStore.Domain.Base;
using VideoStore.Domain.Movies.Contracts;
using VideoStore.Domain.Movies.Repositories;

namespace VideoStore.Application.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IValidator<MovieCommand> _validator;
        private readonly IMovieMapper _movieMapper;
        private readonly IMovieServiceBuilder _movieServiceBuilder;

        public MovieService(
            IMovieRepository movieRepository,
            IValidator<MovieCommand> validator,
            IMovieMapper movieMapper,
            IMovieServiceBuilder movieServiceBuilder)
        {
            _movieRepository = movieRepository;
            _validator = validator;
            _movieMapper = movieMapper;
            _movieServiceBuilder = movieServiceBuilder;
        }

        public async Task<Result> CreateMovieAsync(MovieCommand movieCommand)
        {
            var (isValid, message) = await _validator.IsValid(movieCommand);

            if (!isValid)
                return ResultHelper.GetErrorResult(message);

            var movie = _movieMapper.MapCommandToEntity(movieCommand);

            await _movieRepository.InsertAsync(movie);

            return new Result(HttpStatusCode.Created);
        }

        public async Task<Result> DeleteMovieAsync(ObjectId id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            movie.Remove();
            await _movieRepository.UpdateAsync(movie);

            return new Result(HttpStatusCode.OK);
        }

        public Result GetAllMovies() 
        { 
            var response = new Result(_movieRepository.GetByExpression(_movieServiceBuilder.Build(), _movieMapper.MapResponse()), HttpStatusCode.OK);

            return response;
        }

        public Result GetMovieById(ObjectId id)
        {
            var builder = _movieServiceBuilder.FilterById(id).Build();
            return new Result(_movieRepository.GetByExpression(builder, _movieMapper.MapResponse()).First(), HttpStatusCode.OK);
        }
        public async Task<Result> UpdateMovieAsync(MovieCommand movieCommand)
        {
            var (isValid, message) = await _validator.IsValid(movieCommand);

            if (!isValid)
                return ResultHelper.GetErrorResult(message);

            var movie = _movieMapper.MapCommandToEntity(movieCommand);

            await _movieRepository.UpdateAsync(movie);

            return new Result(HttpStatusCode.OK);
        }
    }
}
