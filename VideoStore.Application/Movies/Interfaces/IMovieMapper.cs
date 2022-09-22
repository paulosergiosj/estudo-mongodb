using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VideoStore.Domain.Movies.Contracts;
using VideoStore.Domain.Movies.Entities;

namespace VideoStore.Application.Movies.Interfaces
{
    public interface IMovieMapper
    {
        ObjectResult MapDtoToObjectResultEntity(MovieDto dto);
        ObjectResult MapEntitiesToDtoObjectResult(IEnumerable<Movie> movies);
        ObjectResult MapEntityToDtoObjectResult(Movie movie);
    }
}
