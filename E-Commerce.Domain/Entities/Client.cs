using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace E_Commerce.Domain.Entities
{

    public class Client : BassEntites
    {

      
        [BsonElement("Full Name")]
        [JsonPropertyName("Full Name")]
        public string Name { get; protected set; }
        public string Email { get;private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public bool IsActive { get; private set; }
       

       
        private Client(string id, string name, string email, string address, string phone, DateTime dateOfBirth, DateTime registrationDate)
        {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            RegistrationDate = registrationDate;
            IsActive = true;
        }

        public static Client Register(string name, string email, string address, string phone, DateTime dateOfBirth)
        {
            return new Client(ObjectId.GenerateNewId().ToString(), name, email, address, phone, dateOfBirth, DateTime.UtcNow);
        }

        public void UpdateContactInfo(string newEmail, string newPhone)
        {
            if (IsActive==false)
            {
                throw new Exception("User is not Ative");
            }
            Email = newEmail;
            Phone = newPhone;

        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }

}

