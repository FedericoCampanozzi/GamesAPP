using GamesAPP.Shared.Entities;

namespace GamesAPP.Shared.Services
{
    public interface IGameService
    {
        Task<List<Game>> GetAllGames();
        Task<Game> AddGame(Game game);
    }
}
