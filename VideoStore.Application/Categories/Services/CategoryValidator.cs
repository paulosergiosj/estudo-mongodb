using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStore.Domain.Categories.Repositories;

namespace VideoStore.Application.Categories.Services
{
    public class CategoryValidator : ICategoryValidator
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> IsCategoriesIdvalid(IEnumerable<ObjectId> categoriesId)
        {
            foreach (var id in categoriesId)
                if (!await IsCategoryIdValid(id))
                    return false;

            return true;
        }

        public async Task<bool> IsCategoryIdValid(ObjectId id)
        {
            return await _categoryRepository.ExistAsync(id);
        }
    }
}
