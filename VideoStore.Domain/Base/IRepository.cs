using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VideoStore.Domain.Models;

namespace VideoStore.Domain.Base
{
    public interface IRepository<TEntity>  where TEntity : class, IEntity<ObjectId>
    {
        Task<ObjectId> InsertAsync(TEntity entity);
        Task<bool> RemoveAsync(ObjectId id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(ObjectId id);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> RemoveLogicAsync(ObjectId id);
        IEnumerable<TSelect> GetByExpression<TSelect>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TSelect>> selector);
    }
}