using MongoDB.Bson;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using VideoStore.Domain.Base;
using VideoStore.Domain.Categories.Contracts;
using VideoStore.Domain.Categories.Entities;

namespace VideoStore.Application.Categories.Interfaces
{
    public interface ICategoryService
    {
        Task<Result> CreateCategory(CategoryCommand category);
        Task<Result> DeleteCategory(ObjectId id);
        Result GetAllCategories();
        Result GetCategoryById(ObjectId id);
        Task<Result> UpdateCategory(CategoryCommand category);
    }
}