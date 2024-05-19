using AirGroup.Service.DTOS.OrderDtos;
using AirGroup.Service.DTOS.ProductDtos;
using AirGroup.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    
    public class OrderController : BaseController
    {
        private readonly IOrderService _service;
        private readonly ICurrentUser _currentUser;
        public OrderController(IOrderService service, ICurrentUser currentUser)
        {
            _service = service;
            _currentUser = currentUser;
        }

        [HttpPost]
        [Route("CreateOrder")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Create([FromBody] OrderCreateDto ordertDto)
        {
            if (ordertDto == null) { return BadRequest() ; }
            var currentUser = _currentUser.GetCurrentUser();
            await _service.CreateOrderAsync(ordertDto, currentUser.UserId);
            return Ok("Order Created");
        }
        [HttpDelete]
        [Route("DeleteOrder/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Order Deleted");
        }

        [HttpGet]
        [Route("GetAllOrder")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllOrder()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("GetUserOrderHistory")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUserOrderHistoryAsync()
        {
            var currentUser = _currentUser.GetCurrentUser();
            return Ok(await _service.GetUserOrderHistoryAsync(currentUser.UserId));
        }
    }
}
