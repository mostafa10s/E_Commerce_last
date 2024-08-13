using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace E_Commerce.Application.Common.Dto
{
    public class UpdateClientDto
    {


        [BsonElement("FullName")]
        [JsonPropertyName("FullName")]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }
        [Phone]
        public string Phone { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DateOfBirth { get; set; }

    }
}
