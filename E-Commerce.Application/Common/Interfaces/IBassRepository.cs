using MongoDB.Driver;

namespace E_Commerce.Application.Common.Interfaces
{
    public interface IBassRepository<T> where T : class 
    {

        Task CreateAsync(T entity);
        Task DeleteAsync(FilterDefinition<T> filter);
        Task UpdateAsync(FilterDefinition<T> filter,  T entity);
        Task<T> GetOne(FilterDefinition<T> filter);
        Task<IEnumerable<T>> GetAll();
    }
   
}
