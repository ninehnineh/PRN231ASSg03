using DTO.OrderDetailDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderDetailRepository
{
    public interface IOrderDetailRepository
    {
        Task CreateOrderDetailAsync(CreateOrderDetailDto orderDetailDto);
    }
}
