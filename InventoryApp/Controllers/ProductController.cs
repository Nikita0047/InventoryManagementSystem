
    using InventoryModels.DTOs;
    using InventoryService.Services.IServices;
    using Microsoft.AspNetCore.Mvc;

    namespace InventoryApp.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ProductController : ControllerBase
        {
            private readonly IProductService _productService;

            public ProductController(IProductService productService)
            {
                _productService = productService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var products = await _productService.GetAllProductsAsync();
                return Ok(products);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var product = await _productService.GetProductByIdAsync(id);

                if (product == null)
                    return NotFound("Product not found");

                return Ok(product);
            }

            [HttpPost]
            public async Task<IActionResult> Create(ProductDto dto)
            {
                var createdProduct = await _productService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = createdProduct.Id },
                    createdProduct
                );
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, ProductDto dto)
            {
                var result = await _productService.GetProductByIdAsync(id);
                if (result == null)
                    return NotFound("Product not found");

                await _productService.UpdateAsync(id, dto);
                return Ok("Product updated successfully");
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var result = await _productService.GetProductByIdAsync(id);
                if (result == null)
                    return NotFound("Product not found");
                await _productService.DeleteAsync(id);
                return Ok("Product deleted successfully");
            }
        }
    }

