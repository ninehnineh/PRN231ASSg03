using AutoMapper;
using BusinessObject;
using DataAccess.ProductDAO;
using DTO.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ProductDAO _productDao;

        public ProductRepository(EStoreDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _productDao = new ProductDAO(_dbContext, _mapper);
        }

        public async Task<List<ProductListDto>> GetProductsAsync()
        {
            return await _productDao.GetProductsAsync();
        }

        public async Task<ProductDetailsDto> GetProductAsync(int id)
        {
            return await _productDao.GetProductAsync(id);
        }

        public async Task UpdateProductQuantityAsync(UpdateProductQuantityDto updateProductDto)
        {
            await _productDao.UpdateProductQuantityAsync(updateProductDto);
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
            => await _productDao.CreateAsync(createProductDto);

        public async Task DeleteProductAsync(int id)
            => await _productDao.DeleteAsync(id);

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
            => await _productDao.UpdateAsync(updateProductDto);
    }
}
