using AutoMapper;
using BusinessObject;
using DataAccess.OrderDAO;
using DataAccess.OrderDetailDAO;
using DTO.OrderDetailDTOs;
using DTO.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderDetailRepository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly EStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly OrderDetaiDAO _orderDetailDAO;

        public OrderDetailRepository(EStoreDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _orderDetailDAO = new OrderDetaiDAO(_dbContext, _mapper);
        }

        public async Task CreateOrderDetailAsync(CreateOrderDetailDto orderDetailDto)
        {
            await _orderDetailDAO.CreateAsync(orderDetailDto);
        }
    }
}
