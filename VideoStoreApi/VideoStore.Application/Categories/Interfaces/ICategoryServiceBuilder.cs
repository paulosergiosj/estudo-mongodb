using MongoDB.Bson;
using VideoStore.Domain.Base;
using VideoStore.Domain.Categories.Entities;

namespace VideoStore.Application.Categories.Interfaces
{
    public interface ICategoryServiceBuilder : IServiceBuilderBase<Category>
    {
        ICategoryServiceBuilder FilterById(ObjectId id);
    }
}