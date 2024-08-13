using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.Common.Dto
{
    public class UpdateContactInfoClientDto
    {
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
