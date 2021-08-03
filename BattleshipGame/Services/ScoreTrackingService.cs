using System.Threading.Tasks;
using BattleshipGame.DomainObjects;
using BattleshipGame.Entities;
using BattleshipGame.Repositories.Interfaces;
using BattleshipGame.Services.Interfaces;
using Microsoft.Extensions.Logging;
using BattleshipGame.Extensions;

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
            //Get Player using GameGUID and PlayerGUID
            // from player get gameboard
            Game game = await _gameRepository.GetGameById(request.GameGUID);
            Player opponent = null;
            Player player = null;
            if (game.Player1.GUID.Equals(request.PlayerGUID))
            {
                opponent = game.Player2;
                player = game.Player1;
            }
            else
            {
                opponent = game.Player1;
                player = game.Player2;
            }
            
            MoveOutcome outcome = opponent.GameBoard.BattleshipPlacements.Exists(item => item.IsHit(request.AttackCoordinates)) ? MoveOutcome.Hit : MoveOutcome.Miss;
            player.ScoreBoard.ExecuteMove(request.AttackCoordinates, outcome);
            AttackResponse retVal = new AttackResponse(true, outcome.GetDescription());
            return retVal;
        }
    }
}
