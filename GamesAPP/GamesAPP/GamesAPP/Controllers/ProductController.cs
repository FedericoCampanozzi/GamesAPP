using GamesAPP.Shared.Entities;
using GamesAPP.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamesAPP.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProductById(int id)
		{
			var product = await _productService.GetProductById(id);
			return Ok(product);
		}

		[HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            var addedProduct = await _productService.AddProduct(product);
            return Ok(addedProduct);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Product>> EditProduct(int id, Product product)
		{
			var updatedProduct = await _productService.EditProduct(id, product);
			return Ok(updatedProduct);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Product>> DeleteGame(int id)
		{
			var result = await _productService.DeleteProduct(id);
			return Ok(result);
		}
	}
}
