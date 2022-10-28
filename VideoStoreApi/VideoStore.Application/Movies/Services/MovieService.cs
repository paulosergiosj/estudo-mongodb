using MongoDB.Bson;
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

        public MovieService(IMovieRepository movieRepository, IValidator<MovieCommand> validator, IMovieMapper movieMapper)
        {
            _movieRepository = movieRepository;
            _validator = validator;
            _movieMapper = movieMapper;
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

        public async Task<Result> GetAllMoviesAsync() => new Result(await _movieRepository.GetAllAsync(), HttpStatusCode.OK);

        public async Task<Result> GetMovieByIdASync(ObjectId id) => new Result(await _movieRepository.GetByIdAsync(id), HttpStatusCode.OK);

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
