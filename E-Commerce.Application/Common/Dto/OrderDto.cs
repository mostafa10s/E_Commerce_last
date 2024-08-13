
namespace E_Commerce.Application.Common.Dto
{
    public class OrderDto
    {

        public string ClientId { get; set; }


        public decimal TotalAmount { get; set; }

        //public List<string> OrderItems { get; set; }
        //enum
        //public List<string> Status { get; set; }

        public string ShippingAddress { get; set; }

        public string PaymentMethod { get; set; }
    }
}
