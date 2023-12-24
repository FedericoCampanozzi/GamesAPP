using GamesAPP.Shared.Data;
using GamesAPP.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesAPP.Shared.Services
{
    public class GameService : IGameService
    {
        private readonly DataContext _context;

        public GameService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Game>> GetAllGames()
        {
            var games = await _context.Games.ToListAsync();
            return games;
        }

        public async Task<Game> AddGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return game;
        }

		async Task<Game> IGameService.GetGameById(int id)
		{
			return await _context.Games.FindAsync(id);
		}
	}
}
