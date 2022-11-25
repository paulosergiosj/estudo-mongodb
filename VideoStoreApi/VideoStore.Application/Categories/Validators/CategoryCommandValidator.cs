using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Domain.Base;
using VideoStore.Domain.Categories.Contracts;
using VideoStore.Domain.Categories.Repositories;
using VideoStore.Domain.Models.Enums;

namespace VideoStore.Application.Categories.Validators
{
    public class CategoryCommandValidator : Validator<CategoryCommand>, IValidator<CategoryCommand>
    {
        private const string CATEGORYID_INVALID = @"Category {0} invalid";

        private readonly ICategoryRepository _categoryRepository;

        public CategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public new async Task<(bool, string)> IsValid(CategoryCommand category)
        {
            ObjectId idParsed;
            if(category.Operation == Operation.Update && (!ObjectId.TryParse(category.Id, out idParsed) || !await _categoryRepository.ExistAsync(idParsed)))
            {
                return (false, String.Format(CATEGORYID_INVALID, category.Id));
            }
            return (true, null);
        }
    }
}
