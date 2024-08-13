

namespace E_Commerce.Application.Services.Interface
{
    public interface IClientServices : IBassServices<Client>
    {

        Task<Client> Registertion(string name, string email, string address, string phone, DateTime dateOfBirth);
        Task UpdateInfo(string id, string email, string phone);
        Task Deavtive(string id);
      




    }
}
