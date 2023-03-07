using DTO.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderRepository
{
    public interface IOrderRepository
    {
        Task<CreateOrderResponse> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<IEnumerable<OrderListDto>> GetOrderListsAsync(string userId);
    }
}
