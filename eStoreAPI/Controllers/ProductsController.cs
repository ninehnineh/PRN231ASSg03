using DTO.ProductDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.ProductRepository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Customer")]

    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductListDto>>> Get()
        {
            var products = await _productRepository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var products = await _productRepository.GetProductAsync(id);
            return products == null ? NotFound() : Ok(products);
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateProductQuantityDto updateProductDto)
        {
            await _productRepository.UpdateProductQuantityAsync(updateProductDto);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateProductDto createProductDto)
        {
            await _productRepository.CreateProductAsync(createProductDto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _productRepository.DeleteProductAsync(id);
            return NoContent();
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(UpdateProductDto updateProductDto)
        {
            await _productRepository.UpdateProductAsync(updateProductDto);
            return NoContent();
        }
    }
}
