

using E_Commerce.Application.Services.Implementation;
using E_Commerce.Application.Services.Interface;
using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Services.Implementations
{
    public class ProductServices :IProductServices

    {

        private readonly IProductRepository _productRepository;
        private readonly ICategoryServices _categoryServices;
        public ProductServices(IProductRepository productRepository, ICategoryServices categoryServices)
        {
            _productRepository = productRepository;
            _categoryServices = categoryServices;
        }
        public async Task<IEnumerable<Product>> GetAsync() => await _productRepository.GetAll();
        public async Task<(Product Obj, FilterDefinition<Product> Filt)> GetOneAsync(string id)
        {

            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                // If the id is not valid, return null
                return (null,null);
            }
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            var data = await _productRepository.GetOne(filter);
            return (data, filter) ;
        }
        public async Task<Product> CreateProduct(string name, string description, decimal price, string categoryId, int stock, string manufacturer)
        {
            var categoryData = await _categoryServices.GetOneAsync(categoryId);
            if (categoryData.Obj == null)
            {
                throw new Exception("the CategoryID is Not Correct");
            }
            var product = Product.Create(name, description, price, categoryId, stock, manufacturer);
            await _productRepository.CreateAsync(product);
            return product;
        }
     
        public async Task<Product> UpdateStock(string id ,int stock)
        {
            var product = await GetOneAsync(id);
                if (product.Obj == null) {

                throw new Exception("no  ProductId like that");
            }
            product.Obj.UpdateStock(stock);
        
            await _productRepository.UpdateAsync(product.Filt, product.Obj);
            return product.Obj;
        }
        public async Task<Product> Updatepercentage(string id, decimal percentage)
        {
            var product = await GetOneAsync(id);
            if (product.Obj == null)
            {

                throw new Exception("no  ProductId like that");
            }
            product.Obj.ApplyDiscount(percentage);
            
            await _productRepository.UpdateAsync(product.Filt, product.Obj);
            return product.Obj;
        }


        public async Task<bool> DeleteAsync(string id) {
            var product = await GetOneAsync(id);
            if (product.Obj == null)
            {

                return false ;
            }

          
            await _productRepository.DeleteAsync(product.Filt);
            return true;
        }

       
    }
 
}
