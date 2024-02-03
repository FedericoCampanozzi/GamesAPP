using GamesAPP.Shared.Data;
using GamesAPP.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesAPP.Shared.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

		async Task<Product> IProductService.GetProductById(int id)
		{
			return await _context.Products.FindAsync(id);
		}

		public async Task<Product> EditProduct(int id, Product product)
		{
			var dbProduct = await _context.Products.FindAsync(id);
			if (dbProduct != null)
			{
				dbProduct.Name = product.Name;
                dbProduct.Description = product.Description;
				await _context.SaveChangesAsync();
				return dbProduct;
			}
            throw new Exception("Product not found");
		}

		public async Task<bool> DeleteProduct(int id)
		{
			var dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct != null)
            {
                _context.Remove(dbProduct);
                await _context.SaveChangesAsync();
                return true;
            }
            else 
            { 
                return false; 
            }
		}
	}
}
