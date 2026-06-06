using CrudAppliction.Data;
using CrudAppliction.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudAppliction.Services
{
    public class ProductService : IProductService
    {


        // Inject Dependancy injection
        private readonly AppDbContext context;

        public ProductService(AppDbContext appDbContext)
        {

            context = appDbContext;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync(); // Saves to SQL Server and updates the 'product.Id' field automatically
            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            // Step 1: Find the product in the database
            var productToDelete = await context.Products.FindAsync(id);


            // Step 2: If it doesn't exist, return false to let the controller know it's a 404
            if (productToDelete == null)
            {
                return false;
            }

            // Step 3: Tell Entity Framework to track this object for deletion
            context.Products.Remove(productToDelete);

            // Step 4: Commit the deletion to your actual SQL Server database
            await context.SaveChangesAsync();

            // Step 5: Return true indicating a successful deletion
            return true;

        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            // Uses EF Core ToListAsync() to pull records asynchronously
            return await context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task<Product?> UpdateProductAsync(int id, Product product)
        {
            // Step 1: Find the database record
            var existingProduct = await context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return null;
            }

            // Step 2: Validate fields before overwriting (Avoids putting blanks/nulls into the DB)
            if (!string.IsNullOrWhiteSpace(product.Name))
            {
                existingProduct.Name = product.Name;
            }

            if (product.Price > 0)
            {
                existingProduct.Price = product.Price;
            }

            if (product.Description != null)
            {
                existingProduct.Description = product.Description;
            }

            // Step 3: Save changes to SQL Server
            await context.SaveChangesAsync();

            return existingProduct;
        }
    }
}
