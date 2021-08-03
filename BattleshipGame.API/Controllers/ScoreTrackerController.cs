using System.Collections.Generic;
using BattleshipGame.DomainObject.Boards;
using BattleshipGame.DomainObjects;
using BattleshipGame.DomainObjects.Boards;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BattleshipGame.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoreTrackerController : ControllerBase
    {
        private readonly ILogger<ScoreTrackerController> _logger;
        private readonly IList<Game> _gameRepository;

        public ScoreTrackerController(ILogger<ScoreTrackerController> logger, IList<Game> GameRepository)
        {
            _logger = logger;
            _gameRepository = GameRepository;
        }

        

        [HttpPost("Attack")]
        public AttackMove Attack(string GameGUID, string PlayerGUID, Coordinates Coordinates)
        {
            return new AttackMove(Coordinates);            
        }


    }
}