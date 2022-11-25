using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStore.Domain.Base;
using VideoStore.Domain.Categories.Repositories;
using VideoStore.Domain.Models.Enums;
using VideoStore.Domain.Movies.Contracts;
using VideoStore.Domain.Movies.Repositories;

namespace VideoStore.Application.Movies.Validators
{
    public class MovieCommandValidator : Validator<MovieCommand>, IValidator<MovieCommand>
    {
        private const decimal MIN_RATE = 0;
        private const decimal MAX_RATE = 10;
        private const string RATE_OUT_OF_RANGE = @"The Rate must be between {0} and {1}.";
        private const string CATEGORYID_INVALID = @"There are invalid Categories!";
        private const string MOVIEID_INVALID = @"Movie invalid!";

        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public MovieCommandValidator(IMovieRepository movieRepository, ICategoryRepository categoryRepository)
        {
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;

            Must(x =>
                   decimal.Compare(x.Rate, MIN_RATE) >= 0
                && decimal.Compare(x.Rate, MAX_RATE) <= 0,
                string.Format(RATE_OUT_OF_RANGE, MIN_RATE, MAX_RATE));
            Must(x => IsMovieIdValid(x).GetAwaiter().GetResult(), MOVIEID_INVALID);
            Must(x => IsCategoriesIdValid(x.Categories).ConfigureAwait(false).GetAwaiter().GetResult(), CATEGORYID_INVALID);
        }

        private async Task<bool> IsCategoriesIdValid(IEnumerable<string> categoriesId)
        {
            var isValid = true;
            ObjectId id;

            foreach (var category in categoriesId)
            {
                if (!ObjectId.TryParse(category, out id) || !await _categoryRepository.ExistAsync(id))
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        private async Task<bool> IsMovieIdValid(MovieCommand command)
        {
            if (command.Operation != Operation.Update) return true;

            ObjectId movieId;

            if (!ObjectId.TryParse(command.Id, out movieId) || !await _movieRepository.ExistAsync(movieId))
            {
                return false;
            }

            return true;
        }


    }
}
