using AutoMapper;
using BusinessObject;
using BusinessObject.Entities;
using DTO.OrderDetailDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.OrderDetailDAO
{
    public class OrderDetaiDAO
    {
        private readonly EStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderDetaiDAO(EStoreDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateOrderDetailDto orderDetailDto)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);

            try
            {
                await _dbContext.OrderDetails.AddAsync(orderDetail);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
