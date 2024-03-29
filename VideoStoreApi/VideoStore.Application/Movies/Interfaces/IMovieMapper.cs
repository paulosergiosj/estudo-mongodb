﻿using System;
using System.Linq.Expressions;
using VideoStore.Domain.Movies.Contracts;
using VideoStore.Domain.Movies.Entities;

namespace VideoStore.Application.Movies.Interfaces
{
    public interface IMovieMapper
    {
        Movie MapCommandToEntity(MovieCommand command);
        Expression<Func<Movie, MovieResponse>> MapResponse();
    }
}
