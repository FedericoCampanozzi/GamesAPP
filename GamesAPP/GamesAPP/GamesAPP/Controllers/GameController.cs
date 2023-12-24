﻿using GamesAPP.Shared.Entities;
using GamesAPP.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamesAPP.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GameController : ControllerBase
	{
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            this._gameService = gameService;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Game>> GetGameById(int id)
		{
			var game = await _gameService.GetGameById(id);
			return Ok(game);
		}

		[HttpPost]
        public async Task<ActionResult<Game>> AddGame(Game game)
        {
            var addedGame = await _gameService.AddGame(game);
            return Ok(addedGame);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Game>> EditGame(int id, Game game)
		{
			var updatedGame = await _gameService.EditGame(id, game);
			return Ok(updatedGame);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Game>> DeleteGame(int id)
		{
			var result = await _gameService.DeleteGame(id);
			return Ok(result);
		}
	}
}
