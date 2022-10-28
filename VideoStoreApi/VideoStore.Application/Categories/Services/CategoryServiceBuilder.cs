using MongoDB.Bson;
using VideoStore.Application.Categories.Interfaces;
using VideoStore.Domain.Base;
using VideoStore.Domain.Categories.Entities;

namespace VideoStore.Application.Categories.Services
{
    public class CategoryServiceBuilder : ServiceBuilderBase<Category>, ICategoryServiceBuilder
    {
        public ICategoryServiceBuilder FilterById(ObjectId id)
        {
            AddFilter(x => x.Id == id);

            return this;
        }

    }
}
