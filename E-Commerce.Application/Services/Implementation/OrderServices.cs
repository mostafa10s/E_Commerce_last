

using E_Commerce.Application.Services.Interface;
using E_Commerce.Domain.Const;

namespace E_Commerce.Application.Services.Implementation
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _proudctRepository;
        private readonly IProductServices _productServices;
        private readonly IClientServices _clienttServices;
   


        public OrderServices(IOrderRepository OrderRepository , IClientServices clienttServices, IProductServices productServices)
        { 
        
        
            _orderRepository = OrderRepository;

            _clienttServices = clienttServices;
            _productServices =productServices;

        }
        public async Task<IEnumerable<Order>> GetAsync() => await _orderRepository.GetAll();

        public async Task<(Order Obj, FilterDefinition<Order> Filt  )> GetOneAsync(string id)
        {

            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                // If the id is not valid, return null
                throw new Exception("this Id is not Correct");
            }
            var filter = Builders<Order>.Filter.Eq(p => p.Id, id);
            var data = await _orderRepository.GetOne(filter);
            return (data, filter);
        }
        public async Task<(Order? order ,string? erorrMessage) > CreateOrder(string clientId, string shippingAddress, string paymentMethod) {
           
            var filter = Builders<Client>.Filter.Eq(p => p.Id, clientId);
            var chcekIsnotNull = await _clienttServices.GetOneAsync(clientId);
            if (chcekIsnotNull.Obj == null)
            {
               return(null, "the ClientId not found.");
            }

            var order = Order.Create(clientId, shippingAddress, paymentMethod);

            await _orderRepository.CreateAsync(order);
            return (order, null);
        }
        public async Task<(Order? order, string? erorrMessage)> CreateOrderItem(string id, OrderItem item)
        {
            var order = await GetOneAsync(id);
            if (order.Obj == null)
            {

                return (null, "the OrderID not found.");
            }
         
           
            var chcekIsnotNull=  await _productServices.GetOneAsync(item.ProductId);


            if (chcekIsnotNull.Obj == null)
            {
                return (null, "the ProductID not found.");
            }


            order.Obj.AddOrderItem(item);
           
            await _orderRepository.UpdateAsync(order.Filt, order.Obj);

            return (order.Obj,null);
        }

        public async Task<bool> Removeitem(string id ,string productId )
        {
            var order = await GetOneAsync(id);
            if (order.Obj == null)
            {

                return false;
            }
            var chcekIsnotNull = await _proudctRepository.GetOne(productId);

            if (!ObjectId.TryParse(productId, out ObjectId objectId))
            {
                // If the id is not valid, return null
                return false;
            }
            order.Obj.RemoveOrderItem(productId);

            var filter = order.Filt;


        await _orderRepository.UpdateAsync(filter, order.Obj);
            return true;
        }

    public async Task<bool> UpdataStatus(string id, OrderStatus  status) {
            var order = await GetOneAsync(id);
            if (order.Obj == null)
            {

                return false;
            }
            order.Obj.UpdateStatus(status);
            var filter = order.Filt;
            await _orderRepository.UpdateAsync(filter, order.Obj);
                return true;
        }


        public async Task<bool> DeleteAsync(string id)
        {
            var order = await GetOneAsync(id);
            if (order.Obj == null)
            {

                return false;
            }

            var filter = order.Filt;
            await _orderRepository.DeleteAsync(filter);
            return true;
        }

      
    }
}

