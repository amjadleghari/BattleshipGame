using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BattleshipGame.DomainObject.Boards;
using BattleshipGame.DomainObjects;
using BattleshipGame.DomainObjects.Boards;
using BattleshipGame.Entities;
using BattleshipGame.Exceptions;
using BattleshipGame.Results;
using BattleshipGame.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BattleshipGame.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoreTrackerController : ControllerBase
    {
        private readonly ILogger<ScoreTrackerController> _logger;
        private readonly IScoreTrackingService _scoreTrackingService;

        public ScoreTrackerController(ILogger<ScoreTrackerController> logger, IScoreTrackingService ScoreTrackingService)
        {
            _logger = logger;
            _scoreTrackingService = ScoreTrackingService;
        }

        

        [HttpPost("Attack")]
        public async Task<ActionResult<ApiResult<AttackResponse>>> Attack(AttackRequest request)
        {
            var result = new ApiResult<AttackResponse>();
            try
            {
                result.Data = await _scoreTrackingService.Attack(request);
                return Ok(result);
            }
            catch (GenericBusinessException ex)
            {
                result.AddError(ex.Message, "GenericBusinessError");
                _logger.LogError(ex, $"Attack -->: {ex.Message}");
                return new ObjectResult(result)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message, "TechnicalError");
                _logger.LogError(ex, $"Attack -->: {ex.Message}");
                return new ObjectResult(result)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }


    }
}