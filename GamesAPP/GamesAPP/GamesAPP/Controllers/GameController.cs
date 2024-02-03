using GamesAPP.Shared.Entities;
using GamesAPP.Shared.Services;
using Microsoft.AspNetCore.Authorization;
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

		[HttpGet("/get-all")]
		public async Task<ActionResult<List<Product>>> GetAllProducts()
		{
			var games = await _productService.GetAllProducts();
			return Ok(games);
		}

		[HttpGet("{id}"), Authorize]
		public async Task<ActionResult<Product>> GetProductById(int id)
		{
			var game = await _productService.GetProductById(id);
			return Ok(game);
		}

		[HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product p)
        {
            var addedGame = await _productService.AddProduct(p);
            return Ok(addedGame);
		}

		[HttpPut("{id}"), Authorize]
		public async Task<ActionResult<Product>> EditProduct(int id, Product p)
		{
			var updatedGame = await _productService.EditProduct(id, p);
			return Ok(updatedGame);
		}

		[HttpDelete("{id}"), Authorize]
		public async Task<ActionResult<Product>> DeleteProduct(int id)
		{
			var result = await _productService.DeleteProduct(id);
			return Ok(result);
		}
	}
}
