using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Documents;
using WebApi.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("id")]
        public async Task<ActionResult<Product>> CreateProduct(string id)
        {
            var product = await _productRepository.GetAsync(id);
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult> CreateProduct(Product product)
        {
            await _productRepository.CreateAsync(product);
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            await _productRepository.DeleteAsync(id);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult> UpdateProduct(string id, Product updatedProduct)
        {
            var queriedProduct = await _productRepository.GetAsync(id);
            if (queriedProduct == null)
            {
                return NotFound();
            }
            await _productRepository.UpdateAsync(id, updatedProduct);
            return NoContent();
        }
    }
}
