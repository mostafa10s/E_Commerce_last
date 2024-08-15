using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common.Dto.ClientDto
{
    public abstract class BassClenitDto
    {
     
        public string Email { get; set; }

        public string Phone { get; set; }

    }
}
