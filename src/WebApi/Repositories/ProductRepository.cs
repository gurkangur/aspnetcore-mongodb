using WebApi.Data;
using WebApi.Domain.Documents;
using WebApi.Interfaces;

namespace WebApi.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MongoDbContext context) : base(context)
        {
        }
    }
}
