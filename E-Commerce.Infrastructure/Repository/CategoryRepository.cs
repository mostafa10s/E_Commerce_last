

namespace E_Commerce.Infrastructure.Repository
{
    public class CategoryRepository : BassRepository<Category>, ICategoryRepository
    {

     
        public CategoryRepository(MongoDbContext context) : base(context, "Categories")
        {

          

        }


    }
}
