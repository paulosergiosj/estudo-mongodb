using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using VideoStore.Domain.Base;
using VideoStore.Domain.Movies.Contracts;
using VideoStore.Domain.Movies.Entities;

namespace VideoStore.Application.Movies.Interfaces
{
    public interface IMovieService
    {
        Task<Result> CreateMovieAsync(MovieCommand movie);
        Task<Result> DeleteMovieAsync(ObjectId id);
        Task<Result> GetAllMoviesAsync();
        Task<Result> GetMovieByIdASync(ObjectId id);
        Task<Result> UpdateMovieAsync(MovieCommand movie);
    }
}