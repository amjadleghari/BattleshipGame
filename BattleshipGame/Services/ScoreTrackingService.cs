using System.Threading.Tasks;
using BattleshipGame.DomainObjects;
using BattleshipGame.Entities;
using BattleshipGame.Repositories.Interfaces;
using BattleshipGame.Services.Interfaces;
using Microsoft.Extensions.Logging;
using BattleshipGame.Extensions;
using FluentValidation;
using BattleshipGame.Validations;
using BattleshipGame.Exceptions;

namespace BattleshipGame.Services
{
    public class ScoreTrackingService : IScoreTrackingService
    {
        private readonly ILogger<ScoreTrackingService> _logger;

        private readonly IGameRepository _gameRepository;

        public ScoreTrackingService(ILogger<ScoreTrackingService> logger, IGameRepository GameRepository)
        {
            _logger = logger;
            _gameRepository = GameRepository;
        }

        public async Task<AttackResponse> Attack(AttackRequest request)
        {
            try
            { 
                var validator = new AttackRequestValidation();
                validator.ValidateAndThrow(request);

                Game game = await _gameRepository.GetGameById(request.GameGUID);
                Player opponent = null;
                Player player = null;
                if (game.Player1.GUID.ToString().Equals(request.PlayerGUID))
                {
                    opponent = game.Player2;
                    player = game.Player1;
                }
                else
                {
                    opponent = game.Player1;
                    player = game.Player2;
                }

                if (!player.IsItMyTurn)
                {
                    throw new ValidationException($"Its not your turn.");
                }

                if (!game.IsReadyToStart())
                {
                    throw new ValidationException($"players battleship placement are not completed");
                }

                MoveOutcome outcome = opponent.GameBoard.BattleshipPlacements.Exists(item => item.IsHit(request.AttackCoordinates)) ? MoveOutcome.Hit : MoveOutcome.Miss;
                player.ScoreBoard.ExecuteMove(request.AttackCoordinates, outcome);
                opponent.IsItMyTurn = true;
                player.IsItMyTurn = false;
                AttackResponse retVal = new AttackResponse(true, outcome.GetDescription());
                return retVal;
            }
            catch (ValidationException ex)
            {
                _logger.LogError($"Attack failed with error: {ex.Message}");
                throw new GenericBusinessException(ex.Message);
            }
        }
    }
}
