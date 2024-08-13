



using E_Commerce.Application.Common.Dto;
using E_Commerce.Application.Common.Interfaces;
using E_Commerce.Application.Services.Interface;

namespace E_Commerce.Application.Services.Implementation
{
    public class CategoryServices: ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;
        
        public CategoryServices(ICategoryRepository CategoryRepository)
        {
            _categoryRepository = CategoryRepository;
        }
        public async Task<IEnumerable<Category>> GetAsync() => await _categoryRepository.GetAll();
        public async Task<(Category Obj, FilterDefinition<Category> Filt)> GetOneAsync(string id) {

            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                // If the id is not valid, return null
                throw new Exception("this Id is not Correct");
            }

            var filter = Builders<Category>.Filter.Eq(p => p.Id, id);
            var categoryData = await _categoryRepository.GetOne(filter);
            
            return (categoryData, filter);
        }
        public async Task<Category> CreateCategory(string name, string description) 
        {
        var result=Category.Create(name, description);
          
            await _categoryRepository.CreateAsync(result);

          return result;    
                }
      
        public async Task<Category> UpdateatCatgory(string id, string? name, string ? Description)
        {
            var categoryData =await GetOneAsync(id);
            if (categoryData.Obj == null)
            {
                throw new Exception("no CatgeoryID like that");
            }

            if (name != null)
            {
                categoryData.Obj.UpdateName(name);
            }
            if (Description != null)
            {
                categoryData.Obj.UpdateDescription(Description);
            }


            await _categoryRepository.UpdateAsync(categoryData.Filt, categoryData.Obj);
            return categoryData.Obj;
        }
       
        public async Task<bool> DeleteAsync(string id) {

            var categoryData = await GetOneAsync(id);
            if (categoryData.Obj == null)
            {

                return false;
            }
            await _categoryRepository.DeleteAsync(categoryData.Filt);
            return true;
        }

       
    }
    

}

