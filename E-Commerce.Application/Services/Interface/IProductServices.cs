

namespace E_Commerce.Application.Services.Interface
{
    public interface IProductServices : IBassServices<Product>
    {
        Task<Product> CreateProduct(string name, string description, decimal price, string categoryId, int stock, string manufacturer);
        Task<Product> UpdateStock(string id, int stock);
        Task<Product> Updatepercentage(string id, decimal percentage);
    }
}
