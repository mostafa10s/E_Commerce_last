

using E_Commerce.Application.Common.Dto.ProductDto;

using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;

        public ProductController(IProductServices productServices , ICategoryServices categoryServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {


            return await _productServices.GetAsync();
          

        }

        [HttpPost("Create Product")]
        public async Task<IActionResult> Post(ProductDto prodcut )
        {

            

         
           var reuslt= await _productServices.CreateProduct(prodcut.ProductName,prodcut.Description,prodcut.Price,prodcut.CategoryId,prodcut.Stock,prodcut.manufacturer);
            return Ok(reuslt);
        }
        [HttpPut("UpdataProductStocks/{id}")]

        public async Task<IActionResult> UpdataProducts(string id, int stock)
        {
            

            var reuslt = await _productServices.UpdateStock(id, stock);

            return Ok(reuslt);

        }
        [HttpPut("UpdataProductPercentage/{id}")]
        public async Task<IActionResult> UpdataProductPercentage(string id, decimal percentage)
        {
          

            var reuslt = await _productServices.Updatepercentage(id, percentage);

            return Ok(reuslt);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var check= await _productServices.DeleteAsync(id);
            if (check == false)
            {
                return NotFound();
            }

            return Ok("Success Deleteing");
        }

    }
}
