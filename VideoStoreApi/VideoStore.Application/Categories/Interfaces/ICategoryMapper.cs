using System.Linq.Expressions;
using System;
using VideoStore.Domain.Categories.Contracts;
using VideoStore.Domain.Categories.Entities;

namespace VideoStore.Application.Categories.Interfaces
{
    public interface ICategoryMapper
    {
        Category MapCommandToEntity(CategoryCommand categoryCommand);
        Expression<Func<Category, CategoryResponse>> MapResponse();
    }
}