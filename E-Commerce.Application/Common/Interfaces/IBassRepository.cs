using MongoDB.Driver;
using System.Linq.Expressions;

namespace E_Commerce.Application.Common.Interfaces
{
    public interface IBassRepository<T> where T : class 
    {

        Task CreateAsync(T entity);
        Task DeleteAsync(FilterDefinition<T> filter);
        Task UpdateAsync(FilterDefinition<T> filter,  T entity);
        Task<T> GetOne(FilterDefinition<T> filter);
        Task<IEnumerable<T>> GetAll();
      //  Task<IEnumerable<T>> GetAllAsync(
      //Expression<Func<T, bool>> filter = null,
      //Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
      //int? page = null,
      //int? pageSize = null);

    }
   
}
