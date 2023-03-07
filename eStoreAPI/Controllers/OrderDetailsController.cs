using DTO.OrderDetailDTOs;
using DTO.OrderDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.OrderDetailRepository;
using Repository.OrderRepository;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Customer")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailsController(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        [HttpPost]
        public async Task Create(CreateOrderDetailDto orderDetailDto)
        {
            await _orderDetailRepository.CreateOrderDetailAsync(orderDetailDto);
        }
    }
}
