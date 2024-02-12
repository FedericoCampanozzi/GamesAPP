﻿using GamesAPP.Entities;

namespace GamesAPP.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> AddProduct(Product product);
        Task<Product> GetProductById(int id);
		Task<Product> EditProduct(int id, Product product);
		Task<bool> DeleteProduct(int id);
	}
}