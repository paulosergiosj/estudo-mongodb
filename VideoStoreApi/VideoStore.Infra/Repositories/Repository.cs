using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VideoStore.Domain.Base;
using VideoStore.Domain.Models;
using VideoStore.Infra.Constants;

namespace VideoStore.Infra.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<ObjectId>
    {
        private readonly IMongoCollection<TEntity> _collection;

        public Repository(IMongoClient client)
        {
            var dataBase = client.GetDatabase(ConnectionStringsConstants.DATABASE);
            _collection = dataBase.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task InsertAsync(TEntity entity) => await _collection.InsertOneAsync(entity);

        public IEnumerable<TSelect> GetByExpression<TSelect>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TSelect>> selector)
        {
            var query =
            _collection.AsQueryable()
                 .Where(where)
                 .Select(selector);

            return query;
        }

        public async Task<TEntity> GetByIdAsync(ObjectId id)
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);
            var entity = await _collection.Find(filter).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<bool> ExistAsync(ObjectId id) => await GetByIdAsync(id) != null;


        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await _collection.Find(_ => true).ToListAsync();

            return entities;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            var result = await _collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new ReplaceOptions { IsUpsert = true });

            return result.ModifiedCount == 1;
        }

        public async Task<bool> RemoveAsync(ObjectId id)
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);
            var result = await _collection.DeleteOneAsync(filter);

            return result.DeletedCount == 1;
        }
    }
}
