using AutoMapper;
using BusinessObject;
using BusinessObject.Entities;
using DTO.OrderDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.OrderDAO
{
    public class OrderDAO
    {
        private readonly EStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderDAO(EStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CreateOrderResponse> CreateAsync(CreateOrderDto orderModel)
        {
            var order = _mapper.Map<Order>(orderModel);

            try
            {
                order.AspNetUsersId = orderModel.UserId.ToString();
                await _dbContext.Orders.AddAsync(order);
                await _dbContext.SaveChangesAsync();
                return new CreateOrderResponse { OrderId = order.Id };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<OrderListDto>> GetOrderListAsync(string userId)
        {
            var orders = new List<Order>();
            try
            {
                orders = await _dbContext.Orders.Include(x => x.OrderDetails)
                    .ThenInclude(x => x.Product)
                    .Where(x => x.AspNetUsersId == userId)
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return _mapper.Map<IEnumerable<OrderListDto>>(orders);

        }
    }
}
