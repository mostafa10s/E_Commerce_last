
using E_Commerce.Application.Services.Implementation;
using E_Commerce.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClintController : ControllerBase
    {

   
        private readonly IClientServices _clientServices;
        public ClintController(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }



        [HttpGet]
        public async Task<IEnumerable<Client>> GetAll()
        {
         

            return await _clientServices.GetAsync();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne( string id)
        {
            
          var user=  await _clientServices.GetOneAsync(id);
            if (user.Obj == null || user.Obj.IsActive == false)
            {
                return BadRequest("no such id like that");

            }


            return Ok(user);
        }
       
      

      

       
        [HttpPost]
        public async Task<IActionResult> Register( ClientDto Client)
        {


         var userData =  await _clientServices.Registertion(Client.Name, Client.Email,Client.Address,Client.Phone,Client.DateOfBirth);

            return  Ok(userData);
        }
        [HttpPut("UpdateContactInfo/{id}")]


        public async Task<IActionResult> UpdateContactInfo(string id, UpdateContactInfoClientDto input)
        {
         

            await _clientServices.UpdateInfo(id, input.Email,input.Phone);

            return NoContent();

        }

        [HttpPut("Deactive/{id}")]
        public async Task<IActionResult> Deactive(string id)
        {

         

           
            await _clientServices.Deavtive(id);

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _clientServices.DeleteAsync(id);
            return NoContent();
        } 


    }
}
