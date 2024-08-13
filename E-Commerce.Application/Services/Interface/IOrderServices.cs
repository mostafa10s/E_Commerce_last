

using E_Commerce.Domain.Const;

namespace E_Commerce.Application.Services.Interface
{
    public interface IOrderServices : IBassServices<Order>
    {
        Task<bool> UpdataStatus(string id, OrderStatus status);
        Task<bool> Removeitem(string id, string productId);
        Task<(Order? order, string? erorrMessage)> CreateOrderItem(string id, OrderItem item);
        Task<(Order? order, string? erorrMessage)> CreateOrder(string clientId, string shippingAddress, string paymentMethod);
    }
}
