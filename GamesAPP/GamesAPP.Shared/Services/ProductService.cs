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

        public async Task<Product> AddProduct(Product p)
        {
            _context.Products.Add(p);
            await _context.SaveChangesAsync();

            return p;
        }

		async Task<Product> IProductService.GetProductById(int id)
		{
			return await _context.Products.FindAsync(id);
		}

		public async Task<Product> EditProduct(int id, Product p)
		{
			var dbProduct = await _context.Products.FindAsync(id);
			if (dbProduct != null)
			{
				dbProduct.Name = dbProduct.Name;
				dbProduct.Description = dbProduct.Description;
				await _context.SaveChangesAsync();
				return dbProduct;
			}
            throw new Exception("Game not found");
		}

		public async Task<bool> DeleteProduct(int id)
		{
			var dbGame = await _context.Products.FindAsync(id);
            if (dbGame != null)
            {
                _context.Remove(dbGame);
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
