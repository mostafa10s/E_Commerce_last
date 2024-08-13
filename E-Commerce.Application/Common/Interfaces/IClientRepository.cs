



namespace E_Commerce.Application.Common.Interfaces
{
    public interface IClientRepository :IBassRepository<Client>
    {
        Task Register(Client client);
        Task UpdateSpecificElement(FilterDefinition<Client> filter, UpdateDefinition<Client> Client);
        Task Deactivate( Client client);
      
        Task UpdateClient(string id, Client entity);


    }
}
