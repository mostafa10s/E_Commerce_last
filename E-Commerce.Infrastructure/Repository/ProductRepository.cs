

namespace E_Commerce.Infrastructure.Repository
{
    public class ProductRepository : BassRepository<Product>, IProductRepository
    {
        public ProductRepository(MongoDbContext context) : base(context, "Products")
        {

        }
        public async Task<Product> GetOnee(string id)
        {

            var prod = await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return prod;
        }

   
    }
}
