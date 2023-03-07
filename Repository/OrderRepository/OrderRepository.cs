using AutoMapper;
using BusinessObject;
using DataAccess.OrderDAO;
using DataAccess.ProductDAO;
using DTO.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly OrderDAO _orderDAO;

        public OrderRepository(EStoreDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _orderDAO = new OrderDAO(_dbContext, _mapper);
        }

        public async Task<CreateOrderResponse> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            return await _orderDAO.CreateAsync(createOrderDto);
        }

        public async Task<IEnumerable<OrderListDto>> GetOrderListsAsync(string userId)
        {
            return await _orderDAO.GetOrderListAsync(userId);
        }
    }
}
