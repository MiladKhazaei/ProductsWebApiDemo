using ProductsWebApiDemo.DTOs;
using ProductsWebApiDemo.Models;

namespace ProductsWebApiDemo.Services
{
    // Define all methods for CRUD (Create, Read, Update, Delete) operations
    public interface IProductService
    {
        // All products
        Task<List<ProductResponse>> GetAllProductsAsync();
        // Get specific product
        Task<ProductResponse?> GetProductByIdAsync(int id);
        // Create
        Task<ProductResponse> AddNewProductAsync(CreateProductRequest product);
        // Update/Edit
        Task<bool> UpdateProductAsync(int id, UpdateProductRequest product);
        // Delete
        Task<bool> DeleteProductAsync(int id);
    }
}
