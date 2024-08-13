

namespace E_Commerce.Infrastructure.Repository
{
    public class OrderRepository : BassRepository<Order>, IOrderRepository
    {
       
        public OrderRepository(MongoDbContext context) : base(context, "Orders")
        {


        }
      
    }
}
