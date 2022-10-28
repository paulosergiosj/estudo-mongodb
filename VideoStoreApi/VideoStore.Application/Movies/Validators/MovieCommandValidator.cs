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
    public class MovieCommandValidator : IValidator<MovieCommand>
    {
        private const decimal MIN_RATE = 0;
        private const decimal MAX_RATE = 10;
        private const string RATE_OUT_OF_RANGE = @"The field {0} must be greater than {1}.";
        private const string CATEGORYID_INVALID = @"Category {0} invalid";
        private const string MOVIEID_INVALID = @"Movie {0} invalid";

        private string Element;
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public MovieCommandValidator(IMovieRepository movieRepository, ICategoryRepository categoryRepository)
        {
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<(bool, string)> IsValid(MovieCommand command)
        {
            if (decimal.Compare(command.Rate, MIN_RATE) < 0 || decimal.Compare(command.Rate, MAX_RATE) > 0)
            {
                return (false, String.Format(RATE_OUT_OF_RANGE, MIN_RATE, MAX_RATE));
            }

            if (!await IsCategoriesIdValid(command.Categories))
            {
                return (false, String.Format(CATEGORYID_INVALID, Element));
            }

            if (command.Operation.Equals(Operation.Update) && !await IsMovieIdValid(command.Id))
            {
                return (false, String.Format(MOVIEID_INVALID, Element));
            }

            return (true, null);
        }

        private async Task<bool> IsCategoriesIdValid(IEnumerable<string> categoriesId)
        {
            foreach (var category in categoriesId)
            {
                ObjectId id;


                if (!ObjectId.TryParse(category, out id) || !await _categoryRepository.ExistAsync(id))
                {
                    Element = id.ToString();
                    return false;
                }
            }

            return true;
        }

        private async Task<bool> IsMovieIdValid(string id)
        {
            ObjectId movieId;

            if (ObjectId.TryParse(id, out movieId) || !await _movieRepository.ExistAsync(movieId))
            {
                Element = id.ToString();
                return false;
            }

            return true;
        }


    }
}
