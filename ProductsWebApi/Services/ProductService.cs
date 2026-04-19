using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProductsWebApiDemo.Data;
using ProductsWebApiDemo.DTOs;
using ProductsWebApiDemo.Models;

namespace ProductsWebApiDemo.Services
{
    public class ProductService(ApplicationDbContext context) : IProductService
    {
        // Read All
        public async Task<List<ProductResponse>> GetAllProductsAsync()
            // We should map the entity to DTO
            => await context.Products.Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                SellPrice = p.SellPrice,
            }).ToListAsync();
        
        // ReadOne by id
        public async Task<ProductResponse?> GetProductByIdAsync(int id)
        {
            var result = context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    SellPrice = p.SellPrice
                })
                .FirstOrDefaultAsync();
            
            return await result;
            //throw new NotImplementedException();
        }
        // Create
        public async Task<ProductResponse> AddNewProductAsync(CreateProductRequest product)
        {
            var newProduct = new Product
            {
                Name = product.Name,
                TotalCount = product.TotalCount,
                Price = product.Price,
            };
            context.Products.Add(newProduct);
            await context.SaveChangesAsync();

            return new ProductResponse
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Price = newProduct.Price,
            };
        }
        // Update/Edit
        public async Task<bool> UpdateProductAsync(int id, UpdateProductRequest product)
        {
            var existingProduct = await context.Products.FindAsync(id);
            if (existingProduct is null) return false;

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.TotalCount = product.TotalCount;

            await context.SaveChangesAsync();
            
            return true;
        }
        // Delete
        public async Task<bool> DeleteProductAsync(int id)
        {
            var deletingProduct = await context.Products.FindAsync(id);
            if(deletingProduct is null) return false;

            context.Products.Remove(deletingProduct);
            await context.SaveChangesAsync();

            return true;
        }

    }
}
