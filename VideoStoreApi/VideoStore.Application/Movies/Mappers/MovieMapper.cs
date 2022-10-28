using MongoDB.Bson;
using VideoStore.Application.Movies.Interfaces;
using VideoStore.Domain.Models.Enums;
using VideoStore.Domain.Movies.Contracts;
using VideoStore.Domain.Movies.Entities;

namespace VideoStore.Application.Movies.Mappers
{
    public class MovieMapper : IMovieMapper
    {
        public Movie MapCommandToEntity(MovieCommand command)
        {
            var movie = new Movie(command.Title,
                command.DirectorName,
                command.Synopsis,
                command.Rate,
                command.ReleaseDate)
                .AddCategories(command.Categories);

            movie.Id = command.Operation != Operation.Insert ? ObjectId.Parse(command.Id) : ObjectId.Empty;

            return movie;
        }
    }
}
