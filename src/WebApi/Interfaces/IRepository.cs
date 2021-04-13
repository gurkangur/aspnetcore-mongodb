using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi.Domain.Common;

namespace WebApi.Interfaces
{
    public interface IRepository<T> where T : IDocumentBase
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(string id);
        Task<T> UpdateAsync(string id, T entity);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetWhereAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(string id);
    }
}
