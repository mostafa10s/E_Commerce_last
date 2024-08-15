


using E_Commerce.Application.Common.Dto.CategoryDto;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
        

            return await _categoryServices.GetAsync();

        }
        [HttpGet("(id)")]
        public async Task<IActionResult> GetOne(string id)
        {
         

            var catagoryData = await _categoryServices.GetOneAsync(id);
            if (catagoryData.Obj == null)
            {
                return NotFound();
            }
            return Ok(catagoryData.Obj);


        }
        [HttpPost("Create Category")]
        public async Task<IActionResult> Post( CategoryDto Category)
        {
            
         var result  = await _categoryServices.CreateCategory(Category.CategoryName , Category.Description);
            return Ok(result);
        }
        [HttpPut("UpdataCategoryName/{id}")]

        public async Task<IActionResult> UpdataCategoryName(string id, UpdateCategoryNameDto Name)
        {
            

        var result =   await _categoryServices.UpdateatCatgory(id, Name.CategoryName,null );

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }
        [HttpPut("UpdataCategoryDescription/{id}")]

        public async Task<IActionResult> UpdataCategoryDescription(string id, UpdateCategoryDescriptionDto Description)
        {


            var result = await _categoryServices.UpdateatCatgory(id,null ,Description.Description);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _categoryServices.DeleteAsync(id);
            return NoContent();
        }
    }
}
