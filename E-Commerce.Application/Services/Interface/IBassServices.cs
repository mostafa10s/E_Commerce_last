

namespace E_Commerce.Application.Services.Interface
{
    public interface IBassServices<T> where T : class
    {

        Task<IEnumerable<T>> GetAsync();
        Task<(T Obj, FilterDefinition<T> Filt)> GetOneAsync(string id);

        Task<bool> DeleteAsync(string id);


    }
}
