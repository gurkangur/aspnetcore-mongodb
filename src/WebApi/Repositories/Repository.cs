using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Domain.Common;
using WebApi.Interfaces;

namespace WebApi.Repositories
{
    public class Repository<TDocument> : IRepository<TDocument> where TDocument : DocumentBase
    {
        private readonly MongoDbContext _context;
        private IMongoCollection<TDocument> _collection;

        public Repository(MongoDbContext context)
        {
            _context = context;
            _collection = _context._db.GetCollection<TDocument>(context.GetCollectionName(typeof(TDocument)));
        }

        public async Task CreateAsync(TDocument entity)
        {
            await _collection.InsertOneAsync(entity).ConfigureAwait(false);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == new ObjectId(id)).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TDocument>> GetAllAsync()
        {
            return await _collection.AsQueryable().ToListAsync().ConfigureAwait(false);
        }

        public async Task<TDocument> GetAsync(string id)
        {
            var results = await _collection.FindAsync(x => x.Id == new ObjectId(id)).ConfigureAwait(false);
            return await results.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public IEnumerable<TDocument> GetWhereAsync(Expression<Func<TDocument, bool>> predicate)
        {
            return _collection.AsQueryable().Where(predicate).ToList();
        }

        public async Task<TDocument> UpdateAsync(string id, TDocument entity)
        {
            var results = await _collection.ReplaceOneAsync(x => x.Id == new ObjectId(id), entity).ConfigureAwait(false);
            if (results.IsAcknowledged && results.MatchedCount == 1)
                return entity;
            else
                return default;
        }
    }
}
