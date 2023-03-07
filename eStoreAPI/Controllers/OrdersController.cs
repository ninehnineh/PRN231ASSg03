using DTO.OrderDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.OrderRepository;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Customer")]

    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<CreateOrderResponse> Create(CreateOrderDto createOrderDto)
        {
            return await _orderRepository.CreateOrderAsync(createOrderDto);
        }

        [HttpPost("GetOrderList")]
        public async Task<ActionResult<IEnumerable<OrderListDto>>> Get([FromBody] string userId)
        {
            var orders = await _orderRepository.GetOrderListsAsync(userId);
            return Ok(orders);
        }
    }
}
