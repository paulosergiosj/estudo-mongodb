﻿using MongoDB.Bson;
using System;
using System.Linq.Expressions;
using VideoStore.Domain.Models;

namespace VideoStore.Domain.Base
{
    public interface IServiceBuilderBase<TEntity> where TEntity : Entity<ObjectId>
    {
        IServiceBuilderBase<TEntity> FilterById(ObjectId id);
        Expression<Func<TEntity, bool>> Build();
        void AddFilter(Expression<Func<TEntity, bool>> filter);

    }
}