using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VideoStore.Application.Categories.Services
{
    public interface ICategoryValidator
    {
        Task<bool> IsCategoriesIdvalid(IEnumerable<ObjectId> categoriesId);
        Task<bool> IsCategoryIdValid(ObjectId id);
    }
}