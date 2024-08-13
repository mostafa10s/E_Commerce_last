

using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Common.Interfaces
{
    public interface IProductRepository : IBassRepository<Product>
    {
        Task<Product> GetOnee(string id);

    }
}
