using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleshipGame.DomainObjects;
using BattleshipGame.DomainObjects.Battleships;
using BattleshipGame.Entities;
using BattleshipGame.Exceptions;
using BattleshipGame.Repositories.Interfaces;
using BattleshipGame.Services;
using Microsoft.Extensions.Logging;

namespace BattleshipGame.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ILogger<GameService> _logger;

        private readonly IList<Game> _gameRepository;

        public GameRepository(ILogger<GameService> logger, IList<Game> GameRepository)
        {
            _logger = logger;
            _gameRepository = GameRepository;
        }

        public async Task<Game> GetGameById(string GUID)
        {
            Game retVal = null;
            try
            {
                retVal = (from game in _gameRepository
                        where game.GUID.ToString() == GUID
                        select game).FirstOrDefault<Game>();
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetGameById failed with error: {ex.Message}");
                throw new GenericBusinessException(ex.Message);
            }
            return await Task.FromResult<Game>(retVal);
        }

        public async Task<Player> GetPlayerByGameIdAndPlayerId(string gameGUID, string playerGUID)
        {
            Player retVal = null;
            try
            {
                Game game = await GetGameById(gameGUID);
                retVal = (game.Player1.GUID.ToString().Equals(playerGUID)
                    ? game.Player1
                    : (
                        game.Player2.GUID.ToString().Equals(playerGUID)
                        ? game.Player2
                        : null
                        )
                    );
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetGameById failed with error: {ex.Message}");
                throw new GenericBusinessException(ex.Message);
            }
            return await Task.FromResult<Player>(retVal);
        }

        public async Task<Battleship> GetBattleshipByPlayerIdAndShipId(string gameGUID, string playerGUID, string battleshipGUID)
        {
            Player player = await GetPlayerByGameIdAndPlayerId(gameGUID, playerGUID);
            Battleship retVal = (from battleship in player.Battleships
                                     where battleship.GUID.ToString() == battleshipGUID
                                     select battleship).FirstOrDefault<Battleship>();
            return retVal;
        }

        public async Task<Game> CreateGame(string player1Name, string player2Name)
        {
            _gameRepository.Add(
                new Game
                {
                    Player1 = new Player(player1Name, true),
                    Player2 = new Player(player2Name, false)
                }
                );
            return await Task.FromResult<Game>(_gameRepository[_gameRepository.Count - 1]);

        }

        public async Task<IList<Game>> GetAllGames()
        {
            return await Task.FromResult<IList<Game>>(_gameRepository);
        }

        
    }
}
