


using E_Commerce.Application.Common.Dto.OrderDto;
using E_Commerce.Domain.Const;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _ordertServices;
        public OrderController(IOrderServices orderServices)
        {
            _ordertServices = orderServices;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
           

            return await _ordertServices.GetAsync();

        }
        [HttpGet("(id)")]
        public async Task<IActionResult> GetOne(string id)
        {
          

            var order = await _ordertServices.GetOneAsync(id);
            if (order.Obj == null)
            {
                return BadRequest("there is not Order Id like that");
            }

            return
              Ok(order.Obj);

        }
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrders( OrderDto order)
        {
         

       var result=     await  _ordertServices.CreateOrder(order.ClientId,order.ShippingAddress,order.PaymentMethod);
            if (result.erorrMessage != null)
            {
                return BadRequest(result.erorrMessage);
            }
            return Ok(result.order);
        }
        [HttpPut("CreateOrderItem/{id}")]
        public async Task<IActionResult> CreateOrderItem(string id ,OrderItem order)
        {


          var result=  await _ordertServices.CreateOrderItem(id, order);
            if (result.erorrMessage !=null)
            {
                return BadRequest(result.erorrMessage);
            }
            return Ok(result.order);
        }
        [HttpPut("UpdataQuantity/{id}")]
        public async Task<IActionResult> UpdataQuantities(string id, UpdataOrederItemQuantitiesDto order)
        {
            var result = await _ordertServices.UpdateQuantities(id, order.ProductId, order.ProductName, order.Quantity);
            return Ok(result);
        }

        [HttpPut("UpdataStatus/{id}")]
        public async Task<IActionResult> UpdataStatus(string id, OrderStatus order)
        {
            var result = await _ordertServices.UpdataStatus(id, order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _ordertServices.DeleteAsync(id);
            return NoContent();
        }
    }
}
