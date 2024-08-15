
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.Common.Dto.CategoryDto
{
    public class UpdateCategoryNameDto
    {
        [MaxLength(100)]
        [Required]
        public string CategoryName { get; set; }


    }
}
