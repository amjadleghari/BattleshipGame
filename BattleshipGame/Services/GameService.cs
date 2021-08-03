using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using BattleshipGame.Services.Interfaces;
using BattleshipGame.DomainObjects;
using System.Collections.Generic;
using System.Linq;
using BattleshipGame.Repositories.Interfaces;
using BattleshipGame.Entities;
using System.Threading.Tasks;
using FluentValidation;
using BattleshipGame.Validations;
using BattleshipGame.Exceptions;
using BattleshipGame.DomainObjects.Boards;
using BattleshipGame.DomainObjects.Battleships;

namespace BattleshipGame.Services
{
    public class GameService : IGameService
    {
        private readonly ILogger<GameService> _logger;

        private readonly IGameRepository _gameRepository;

        public GameService(ILogger<GameService> logger, IGameRepository GameRepository)
        {
            _logger = logger;
            _gameRepository = GameRepository;
        }

        public async Task<Game> GetGameById(string GUID)
        {
            Game retVal = null;
            try
            {
                if (!Guid.TryParse(GUID, out Guid guidOutput))
                {
                    throw new ValidationException($"invalid GUID");
                }

                retVal =  await _gameRepository.GetGameById(GUID);
            }
            catch (ValidationException ex)
            {
                _logger.LogError($"GetGameById failed with error: {ex.Message}");
                throw new GenericBusinessException(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return retVal;
        }

        public async Task<Game> CreateGame(CreateGameRequest request)
        {
            try
            {
                if (request == null)
                {
                    throw new ValidationException($"empty request data");
                }
                
                var validator = new CreateGameRequestValidation();
                validator.ValidateAndThrow(request);

                return await _gameRepository.CreateGame(request.Player1Name, request.Player2Name);
            }
            catch (ValidationException ex)
            {
                _logger.LogError($"CreateGame failed with error: {ex.Message}");
                throw new GenericBusinessException(ex.Message);
            }
        }

        public async Task<IList<Game>> GetAllGames()
        {
            return await _gameRepository.GetAllGames();
        }

        public async Task<PositionBattleshipResponse> PositionBattleship(PositionBattleshipRequest request)
        {
            try
            {
                var validator = new PositionBattleshipRequestValidation();
                validator.ValidateAndThrow(request);

                PositionBattleshipResponse retVal = new PositionBattleshipResponse();

                Player player = await _gameRepository.GetPlayerByGameIdAndPlayerId(request.GameGUID, request.PlayerGUID);

                Battleship battleship = await _gameRepository.GetBattleshipByPlayerIdAndShipId(request.GameGUID, request.PlayerGUID, request.BattleshipGUID);
                
                retVal.IsPlacementSuccessful = battleship.BattleshipPlacement(request.Coordinates); 
                retVal.Battleship = battleship;

                if (retVal.IsPlacementSuccessful && battleship.Placement.Count > 0)
                {
                    player.GameBoard.BattleshipPlacements.Add(battleship);
                    player.Battleships.Remove(battleship);
                    retVal.IsPlacementSuccessful = true;
                }

                return retVal;
            }
            catch (ValidationException ex)
            {
                _logger.LogError($"PositionBattleship failed with error: {ex.Message}");
                throw new GenericBusinessException(ex.Message);
            }
        }

    }
}
