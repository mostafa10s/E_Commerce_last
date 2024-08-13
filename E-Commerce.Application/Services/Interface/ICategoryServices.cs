

namespace E_Commerce.Application.Services.Interface
{
    public interface ICategoryServices : IBassServices<Category>
    {
        Task<Category> UpdateatCatgory(string id, string? name , string? description);
     
        Task<Category> CreateCategory(string name, string description);
    }
}
