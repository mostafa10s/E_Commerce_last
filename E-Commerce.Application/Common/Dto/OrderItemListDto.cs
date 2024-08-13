namespace E_Commerce.Application.Common.Dto
{
    public class OrderItemListDto
    {
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
    }
}
