using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.Common.Dto.ClientDto
{

    public class ClientDto:BassClenitDto
    {


        public string Name { get; set; }
       
       

        public string Address { get; set; }
      
 
        public DateTime DateOfBirth { get; set; }




    }
}
