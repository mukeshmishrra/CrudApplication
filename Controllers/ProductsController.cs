using CrudAppliction.Models;
using CrudAppliction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudAppliction.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        // Inject ProductService here 
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest("Please enter proper product detail");
            }

            var createdProduct = await _productService.CreateProductAsync(newProduct);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var updateRequestResult = await _productService.UpdateProductAsync(id, updatedProduct);

            if (updatedProduct == null)
            {

                return NotFound($"Product with ID {id} not found.");
            }

            Console.WriteLine($"Product with ID {id} updated successfully.");
            return Ok(updateRequestResult);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // FIXED: Replaced old 'products.Remove()' logic with the Service layer execution
            var isDeleted = await _productService.DeleteProductAsync(id);

            if (!isDeleted)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            return Ok($"Product with ID: {id} deleted successfully.");
        }
    }
}
