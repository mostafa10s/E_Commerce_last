


using E_Commerce.Application.Services.Interface;

namespace E_Commerce.Application.Services.Implementation
{
    public class ClientServices : IClientServices
    {

        private readonly IClientRepository _clientRepository;

        public ClientServices(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<IEnumerable<Client>> GetAsync() => await _clientRepository.GetAll();
        public async Task<(Client Obj, FilterDefinition<Client> Filt)> GetOneAsync(string id)
        {

            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                // If the id is not valid, return null
                throw new Exception("this Id is not Correct");
            }
            var filter = Builders<Client>.Filter.Eq(p => p.Id, id);
            var data = await _clientRepository.GetOne(filter);



            return (data, filter);
        }

        public async Task<Client> Registertion(string name, string email, string address, string phone, DateTime dateOfBirth)
        {
            var client = Client.Register(name, email, address, phone, dateOfBirth);

            await _clientRepository.Register(client);

            return client;
        }
        public async Task UpdateInfo(string id, string email, string phone)
        {

            var client = await GetOneAsync(id);
            if (client.Obj == null)
            {
                throw new Exception("Client not found.");
            }

            client.Obj.UpdateContactInfo(email, phone);
            await _clientRepository.UpdateAsync(client.Filt, client.Obj);

        }

        public async Task Deavtive(string id)
        {
            var client = await GetOneAsync(id);
            if (client.Obj == null)
            {
                throw new Exception("Client not found.");
            }
            client.Obj.Deactivate();

            await _clientRepository.UpdateAsync(client.Filt, client.Obj);

        }

        public async Task<bool> DeleteAsync(string id)
        {
            var client = await GetOneAsync(id);
            if (client.Obj == null)
            {
                return false;
            }
            await _clientRepository.DeleteAsync(client.Filt);
            return true;
        }


    }
}
