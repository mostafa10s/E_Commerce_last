
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.Common.Dto
{
    public class UpdateCategoryNameDto
    {
        [MaxLength(100)]
        [Required]
        public string CategoryName { get; set; }


    }
}
