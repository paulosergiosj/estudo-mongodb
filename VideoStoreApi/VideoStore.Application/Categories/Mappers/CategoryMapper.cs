using MongoDB.Bson;
using System;
using System.Linq.Expressions;
using VideoStore.Application.Categories.Interfaces;
using VideoStore.Domain.Categories.Contracts;
using VideoStore.Domain.Categories.Entities;
using VideoStore.Domain.Models.Enums;

namespace VideoStore.Application.Categories.Mappers
{
    public class CategoryMapper : ICategoryMapper
    {
        public Category MapCommandToEntity(CategoryCommand categoryCommand)
            => new Category
            {
                Id = (categoryCommand.Operation != Operation.Insert) ? ObjectId.Parse(categoryCommand.Id) : ObjectId.Empty,
                Description = categoryCommand.Description
            };

        public Expression<Func<Category, CategoryResponse>> MapResponse()
        {
            return entity => new CategoryResponse
            {
                Id = entity.Id.ToString(),
                Description = entity.Description
            };
        }

    }
}
