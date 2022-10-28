using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VideoStore.Domain.Models;

namespace VideoStore.Domain.Base
{
    public interface IRepository<TEntity> where TEntity : class, IEntity<ObjectId>
    {
        Task InsertAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<bool> ExistAsync(ObjectId id);
        Task<TEntity> GetByIdAsync(ObjectId id);
        Task<bool> UpdateAsync(TEntity entity);
        IEnumerable<TSelect> GetByExpression<TSelect>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TSelect>> selector);
    }
}