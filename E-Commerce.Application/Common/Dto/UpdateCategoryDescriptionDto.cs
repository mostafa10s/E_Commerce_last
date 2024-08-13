using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.Common.Dto
{
    public class UpdateCategoryDescriptionDto
    {
        [MaxLength(150)]
        public string Description { get; set; }

    }
}
