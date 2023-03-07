using DTO.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ProductListDto>> GetProductsAsync();
        Task<ProductDetailsDto> GetProductAsync(int id);

        Task UpdateProductQuantityAsync(UpdateProductQuantityDto updateProductDto);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
    }
}
