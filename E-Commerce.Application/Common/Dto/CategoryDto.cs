

namespace E_Commerce.Application.Common.Dto
{
    public class CategoryDto
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        //[BsonRepresentation(BsonType.DateTime)]
        //public DateTime CreatedDate { get; set; }
        //[BsonRepresentation(BsonType.DateTime)]
        //public DateTime UpdatedDate { get; set; }
    }
}
