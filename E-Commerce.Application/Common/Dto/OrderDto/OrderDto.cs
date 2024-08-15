namespace E_Commerce.Application.Common.Dto.OrderDto
{
    public class OrderDto
    {

        public string ClientId { get; set; }


        public decimal TotalAmount { get; set; }



        public string ShippingAddress { get; set; }

        public string PaymentMethod { get; set; }
    }
}
