

namespace E_Commerce.Infrastructure.Repository
{
    public class ClientRepository:BassRepository<Client>,IClientRepository
    {
       
   

        public ClientRepository(MongoDbContext context ) : base(context, "Clients")
        {

        }
      
        public async Task Deactivate(Client client)
        {
          
        }

     

        public async Task Register(Client client)
        {

            await Collection.InsertOneAsync(client);
        }

        public async Task UpdateSpecificElement(FilterDefinition<Client> filter,UpdateDefinition<Client> Client )
        {

            await Collection.UpdateOneAsync(filter, Client);
        }
        public async Task<Client> GetOnee(string id)
        {

            var user = await Collection.Find(x=>x.Id == id).FirstOrDefaultAsync();
            return user;
        }
        public async Task UpdateClient(string id, Client entity)
        {
            await Collection.ReplaceOneAsync(c=>c.Id==id, entity);
        }
    }
}
