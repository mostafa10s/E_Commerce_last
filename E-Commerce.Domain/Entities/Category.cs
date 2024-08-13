using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Domain.Entities
{

    public class Category: ExtensionBassEntities
    {

 
     
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }

        private Category(string id, string name, string description, DateTime createdDate)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedDate = createdDate;
           
        }

        public static Category Create(string name, string description)
        {
            return new Category(ObjectId.GenerateNewId().ToString(), name, description, DateTime.UtcNow);
        }

        public void UpdateName(string newName)
        {
            Name = newName;
            UpdatedDate = DateTime.UtcNow;
        }

        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
            UpdatedDate = DateTime.UtcNow;
        }
    }
}
   
