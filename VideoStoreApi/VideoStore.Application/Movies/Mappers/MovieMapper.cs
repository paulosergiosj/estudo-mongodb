using MongoDB.Bson;
using System;
using System.Linq;
using System.Linq.Expressions;
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

        public Expression<Func<Movie, MovieResponse>> MapResponse()
        {
            return entity => new MovieResponse
            {
                Id = entity.Id.ToString(),
                DirectorName = entity.DirectorName,
                Rate = entity.Rate,
                ReleaseDate = entity.ReleaseDate,
                Synopsis = entity.Synopsis,
                Title = entity.Title,
                CategoriesId = entity.CategoriesId.Select(x => x.Id.ToString()).ToList()
            };
        }
    }
}
