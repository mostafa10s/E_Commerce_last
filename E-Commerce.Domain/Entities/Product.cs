using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Domain.Entities
{
    public class Product: ExtensionBassEntities
    {
    
       
        public decimal Price { get; private set; }
        public string CategoryId { get; private set; }
        public int Stock { get; private set; }
        public string Manufacturer { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }

        private Product(string id, string name, string description, decimal price, string categoryId, int stock, string manufacturer, DateTime createdDate)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            Stock = stock;
            Manufacturer = manufacturer;
            CreatedDate = createdDate;
         
        }

        public static Product Create(string name, string description, decimal price, string categoryId, int stock, string manufacturer)
        {
            return new Product(ObjectId.GenerateNewId().ToString(), name, description, price, categoryId, stock, manufacturer, DateTime.UtcNow);
        }

        public void UpdateStock(int quantity)
        {
            Stock = quantity;
            UpdatedDate = DateTime.UtcNow;
        }

        public void ApplyDiscount(decimal percentage)
        {
            Price -= Price * (percentage / 100);
            UpdatedDate = DateTime.UtcNow;
        }
    }
}
