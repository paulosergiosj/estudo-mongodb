using MongoDB.Bson;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using VideoStore.Domain.Categories.Entities;

namespace VideoStore.Application.Categories.Interfaces
{
    public interface ICategoryService
    {
        Task<HttpStatusCode> CreateCategory(Category category);
        Task<HttpStatusCode> DeleteCategory(ObjectId id);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryById(ObjectId id);
        Task<HttpStatusCode> UpdateCategory(Category category);
    }
}