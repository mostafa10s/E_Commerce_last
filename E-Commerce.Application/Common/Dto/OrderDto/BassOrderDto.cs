using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common.Dto.OrderDto
{
    public abstract class BassOrderDto
    {
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; set; }
    }
}
