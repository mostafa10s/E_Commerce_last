namespace E_Commerce.Application.Common.Dto
{
    public class ProductUpdateDto
    {

        public string? ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        public int Stock { get; set; }
        public string manufacturer { get; set; }
        public decimal percentage { get; set; }



    }
}
