using GeekShopping.ProductAPI.Infra.Repository.Interfaces;
using GeekShopping.ProductAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> FindAll()
        {
            var products = await _productRepository.FindAllAsync();

            if (products == null) return NotFound();

            return Ok(products);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var product = await _productRepository.FindById(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {
            if (productDto == null) return BadRequest();

            var product = await _productRepository.Save(productDto);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDto productDto)
        {
            if (productDto == null) return BadRequest();

            var product = await _productRepository.Update(productDto);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var isSuccessDelete = await _productRepository.Delete(id);

            if (!isSuccessDelete) return NotFound();

            return Ok(isSuccessDelete);
        }
    }
}
