using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

using E_Commerce.Domain.Const;

namespace E_Commerce.Domain.Entities
{

    public class Order:BassEntites
    {

        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string Id { get; private set; }
        public string ClientId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }
        public decimal TotalAmount { get; private set; }
        [BsonRepresentation(BsonType.String)]
        public OrderStatus Status { get; private set; }
        public string ShippingAddress { get; private set; }
        public string PaymentMethod { get; private set; }

        private Order(string id, string clientId, DateTime orderDate, string shippingAddress, string paymentMethod)
        {
            Id = id;
            ClientId = clientId;
            OrderDate = orderDate;
            OrderItems = new List<OrderItem>();
            TotalAmount = 0;

            Status = OrderStatus.Pending;
            ShippingAddress = shippingAddress;
            PaymentMethod = paymentMethod;
        }

        public static Order Create(string clientId, string shippingAddress, string paymentMethod)
        {
            return new Order(ObjectId.GenerateNewId().ToString(), clientId, DateTime.UtcNow, shippingAddress, paymentMethod);
        }

        public void AddOrderItem(OrderItem item)
        {
            OrderItems.Add(item);
            TotalAmount += item.TotalPrice;
        }

        public void RemoveOrderItem(string productId)
        {
            var item = OrderItems.Find(oi => oi.ProductId == productId);
            if (item != null)
            {
                OrderItems.Remove(item);
                TotalAmount -= item.TotalPrice;
            }
        }
        public void UpdateQuantity(string productId,int quantity , string productName )
        {
            if (Status != OrderStatus.Pending) { return; }

            var item = OrderItems.Find(oi => oi.ProductId == productId && oi.ProductName == productName);
            if (item != null)
            {
                item.UpdateQuantity(quantity);
            }

            }

        public void UpdateStatus(OrderStatus status)
        {
            Status = status;
        }



    }
}

