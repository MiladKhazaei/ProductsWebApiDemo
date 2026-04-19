using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsWebApiDemo.DTOs;
using ProductsWebApiDemo.Services;

namespace ProductsWebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Address: api/products
    // Inject our ProductService to the controller
    public class ProductsController(IProductService productService) : ControllerBase
    {
        // Recieve a list of Products
        [HttpGet]
        public async Task<ActionResult<List<ProductResponse>>> GetProducts() 
            => Ok(await productService.GetAllProductsAsync());

        // Recieve a single product
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetProductById(int id)
        {
            // Product is Task never null
            var product = await productService.GetProductByIdAsync(id);
            return product is null ? NotFound("The Product with the given Id was not found!") : Ok(product);
        }
        // Create
        [HttpPost]
        public async Task<ActionResult<ProductResponse>> AddNewProduct(CreateProductRequest product)
        {
            var createdProduct = await productService.AddNewProductAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct );
        }
        // Update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, UpdateProductRequest product)
        {
            var updated = await productService.UpdateProductAsync(id, product);
            return updated ? NoContent() : NotFound("The Product with the given Id was not found!");
        }
        // Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            var deleted = await productService.DeleteProductAsync(id);
            return deleted ? NoContent() : NotFound("The Product with the given Id was not found!");
        }

    }
}
