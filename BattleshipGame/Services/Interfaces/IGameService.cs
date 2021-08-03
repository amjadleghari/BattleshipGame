using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BattleshipGame.DomainObjects;
using BattleshipGame.Entities;

namespace BattleshipGame.Services.Interfaces
{
    public interface IGameService
    {
        Task<Game> CreateGame(CreateGameRequest request);
        Task<IList<Game>> GetAllGames();
        Task<Game> GetGameById(string gameGUID);
        Task<PositionBattleshipResponse> PositionBattleship(PositionBattleshipRequest request);
    }
}
