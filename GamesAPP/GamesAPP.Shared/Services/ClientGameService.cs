using GamesAPP.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Services
{
	public class ClientGameService : IGameService
	{
		private readonly HttpClient _httpClient;

		public ClientGameService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<bool> DeleteGame(int id)
		{
			var result = await _httpClient.DeleteAsync($"/api/game/{id}");
			return await result.Content.ReadFromJsonAsync<Boolean>();
		}

		public async Task<Game> EditGame(int id, Game game)
		{
			var result = await _httpClient.PutAsJsonAsync<Game>($"/api/game/{id}", game);
			return await result.Content.ReadFromJsonAsync<Game>();
		}

		async Task<Game> IGameService.AddGame(Game game)
		{
			var result = await _httpClient.PostAsJsonAsync<Game>("/api/game", game);
			return await result.Content.ReadFromJsonAsync<Game>();
		}

		Task<List<Game>> IGameService.GetAllGames()
		{
			throw new NotImplementedException();
		}

		async Task<Game> IGameService.GetGameById(int id)
		{
			var result = await _httpClient.GetFromJsonAsync<Game>($"/api/game/{id}");
			return result;
		}
	}
}
