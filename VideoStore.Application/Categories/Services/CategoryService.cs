using MongoDB.Bson;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using VideoStore.Application.Categories.Interfaces;
using VideoStore.Domain.Categories.Entities;
using VideoStore.Domain.Categories.Repositories;

namespace VideoStore.Application.Categories.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<HttpStatusCode> CreateCategory(Category category)
        {
            var id = await _categoryRepository.InsertAsync(category);

            if (id == null)
                return HttpStatusCode.InternalServerError;

            return HttpStatusCode.Created;
        }

        public async Task<HttpStatusCode> DeleteCategory(ObjectId id)
        {
            var success = await _categoryRepository.RemoveLogicAsync(id);

            if (!success)
                return HttpStatusCode.InternalServerError;

            return HttpStatusCode.OK;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return categories;
        }

        public async Task<Category> GetCategoryById(ObjectId id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            return category;
        }

        public async Task<HttpStatusCode> UpdateCategory(Category category)
        {
            var success = await _categoryRepository.UpdateAsync(category);

            if (!success)
                return HttpStatusCode.InternalServerError;

            return HttpStatusCode.OK;
        }
    }
}
