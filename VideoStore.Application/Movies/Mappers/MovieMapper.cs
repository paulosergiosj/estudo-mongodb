using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using VideoStore.Application.Movies.Interfaces;
using VideoStore.Domain.Movies.Contracts;
using VideoStore.Domain.Movies.Entities;

namespace VideoStore.Application.Movies.Mappers
{
    public class MovieMapper : IMovieMapper
    {
        public ObjectResult MapDtoToObjectResultEntity(MovieDto dto)
        {
            List<string> Messages = new List<string>();
            var entity = new Movie(dto.Id,dto.Title, dto.DirectorName, dto.Synopsis, dto.Rate, dto.ReleaseDate);

            foreach (var categoryId in dto.Categories)
                if (!string.IsNullOrEmpty(categoryId))
                {
                    ObjectId id;
                    if (ObjectId.TryParse(categoryId, out id))
                    {
                        entity.AddCategory(id);
                        continue;
                    }
                    Messages.Add(@$"id: '{categoryId}' is not a valid Id");
                }
            if (Messages.Count != 0)
                return new ObjectResult(Messages) { StatusCode = (int)HttpStatusCode.InternalServerError };

            return new ObjectResult(entity);
        }

        public ObjectResult MapEntityToDtoObjectResult(Movie movie)
        {
            var dtoMovie = new MovieDto
            {
                Title = movie.Title,
                DirectorName = movie.DirectorName,
                Rate = movie.Rate,
                ReleaseDate = movie.ReleaseDate,
                Synopsis = movie.Synopsis,
                Categories = new List<string>() { movie.CategoriesId.Select(x => x.Id).ToString() }
            };

            return new ObjectResult(dtoMovie);
        }

        public ObjectResult MapEntitiesToDtoObjectResult(IEnumerable<Movie> movies)
        {
            var moviesDtoList = movies.Select(movie => new MovieDto
            {
                Title = movie.Title,
                DirectorName = movie.DirectorName,
                Rate = movie.Rate,
                ReleaseDate = movie.ReleaseDate,
                Synopsis = movie.Synopsis,
                Categories = movie.CategoriesId.Select(x => x.Id.ToString()).ToList()
            });
            return new ObjectResult(moviesDtoList);
        }
    }
}
