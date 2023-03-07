using AutoMapper;
using BusinessObject;
using BusinessObject.Entities;
using DTO.ProductDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ProductDAO
{
    public class ProductDAO
    {
        private readonly EStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductDAO(EStoreDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> GetProductsAsync()
        {
            var products = await _dbContext.Products.ToListAsync();
            return _mapper.Map<List<ProductListDto>>(products);
        }

        public async Task<ProductDetailsDto> GetProductAsync(int id)
        {
            var product = await _dbContext.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<ProductDetailsDto>(product);
        }

        public async Task UpdateProductQuantityAsync(UpdateProductQuantityDto updateProductDto)
        {
            try
            {
                var productExists = await _dbContext.Products.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == updateProductDto.Id);
                    
                if (productExists != null)
                {
                    productExists.UnitslnStock = updateProductDto.UnitslnStock;
                    _dbContext.Entry<Product>(productExists).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CreateAsync(CreateProductDto productCreateModel)
        {
            var product = _mapper.Map<Product>(productCreateModel);

            try
            {
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(UpdateProductDto productUpdateModel)
        {
            var product = _mapper.Map<Product>(productUpdateModel);

            try
            {
                var productExists = await _dbContext.Products
                    .AnyAsync(x => x.Id == productUpdateModel.Id);
                if (productExists)
                {
                    _dbContext.Entry<Product>(product).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(int Id)
        {
            try
            {
                var product = await _dbContext.Products.FindAsync(Id);

                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
