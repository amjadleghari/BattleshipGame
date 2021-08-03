using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BattleshipGame.DomainObjects;
using BattleshipGame.DomainObjects.Battleships;
using BattleshipGame.Entities;

namespace BattleshipGame.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<Game> CreateGame(string player1Name, string player2Name);

        Task<IList<Game>> GetAllGames();

        Task<Game> GetGameById(string gameGUID);

        Task<Battleship> GetBattleshipByPlayerIdAndShipId(string gameGUID, string playerGUID, string battleshipGUID);

        Task<Player> GetPlayerByGameIdAndPlayerId(string gameGUID, string playerGUID);
    }
}
