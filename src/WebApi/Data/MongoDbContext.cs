using MongoDB.Driver;
using System;
using System.Linq;
using WebApi.Domain.Common;
using WebApi.Domain.Documents;

namespace WebApi.Data
{
    public class MongoDbContext : IMongoDbContext
    {
        public IMongoDatabase _db;
        public MongoDbContext()
        {
            var mongoUrl = new MongoUrl("mongodb://localhost/records");
            var dbname = mongoUrl.DatabaseName;
            _db = new MongoClient(mongoUrl).GetDatabase(dbname);
        }

        public IMongoCollection<Product> Products => _db.GetCollection<Product>(GetCollectionName(typeof(Product)));



        public string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

    }
}
