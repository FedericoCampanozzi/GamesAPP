using GamesAPP.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Services
{
	public class ClientProductService : IProductService
	{
		private readonly HttpClient _httpClient;

		public ClientProductService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<bool> DeleteProduct(int id)
		{
			var result = await _httpClient.DeleteAsync($"/api/product/{id}");
			return await result.Content.ReadFromJsonAsync<Boolean>();
		}

		public async Task<Product> EditProduct(int id, Product product)
		{
			var result = await _httpClient.PutAsJsonAsync<Product>($"/api/product/{id}", product);
			return await result.Content.ReadFromJsonAsync<Product>();
		}

		async Task<Product> IProductService.AddProduct(Product product)
		{
			var result = await _httpClient.PostAsJsonAsync<Product>("/api/product", product);
			return await result.Content.ReadFromJsonAsync<Product>();
		}

		Task<List<Product>> IProductService.GetAllProducts()
		{
			throw new NotImplementedException();
		}

		async Task<Product> IProductService.GetProductById(int id)
		{
			var result = await _httpClient.GetFromJsonAsync<Product>($"/api/product/{id}");
			return result;
		}
	}
}
