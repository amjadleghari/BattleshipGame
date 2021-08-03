using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BattleshipGame.DomainObjects;
using BattleshipGame.DomainObjects.Boards;
using BattleshipGame.Entities;
using BattleshipGame.Exceptions;
using BattleshipGame.Results;
using BattleshipGame.Services.Interfaces;
using BattleshipGame.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BattleshipGame.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameManagementController : ControllerBase
    {
        private readonly ILogger<GameManagementController> _logger;
        private readonly IGameService _gameService;

        public GameManagementController(ILogger<GameManagementController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        /// 1). Call to create new game by mentioning both player names. It will create or update Player information which includes mentioning player name.
        /// 2). Call to place battleship on gameboard. using gameid and playerid as reference. Do validation if all ships are already placed.
        /// 3). Whose move which returns next player name.
        ///
        // create and use following CreateGameRequest(player1name, player2name) and CreateGameResponse(gameGUID, Player1GUID, player1shipGUID, player2GUID, player2shipsGUID) objects
        [HttpPost("CreateGame")]
        public async Task<ActionResult<ApiResult<CreateGameResponse>>> CreateGame(CreateGameRequest request)
        {
            var result = new ApiResult<CreateGameResponse>();
            try
            {
                
                var game = await _gameService.CreateGame(request);

                
                result.Data = new CreateGameResponse
                {
                    GameGUID = game.GUID.ToString(),
                    Player1GUID = game.Player1.GUID.ToString(),
                    Player2GUID = game.Player2.GUID.ToString()
                };
                return Ok(result); 
            }
            catch (GenericBusinessException ex)
            {
                result.AddError(ex.Message, "GenericBusinessError");
                _logger.LogError(ex, $"CreateGame -->: {ex.Message}");
                return new ObjectResult(result)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message, "TechnicalError");
                _logger.LogError(ex, $"CreateGame -->: {ex.Message}");
                return new ObjectResult(result)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        [HttpGet("GetAllGames")]
        public async Task<ActionResult<ApiListResult<IList<Game>>>> GetAllGames()
        {
            var result = new ApiResult<IList<Game>>();
            try
            {
                result.Data = await _gameService.GetAllGames(); 
                return Ok(result);
            }
            catch (GenericBusinessException ex)
            {
                result.AddError(ex.Message, "GenericBusinessError");
                _logger.LogError(ex, $"GetAllGames -->: {ex.Message}");
                return new ObjectResult(result)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message, "TechnicalError");
                _logger.LogError(ex, $"GetAllGames -->: {ex.Message}");
                return new ObjectResult(result)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        [HttpGet("GetGameById")]
        public async Task<ActionResult<ApiResult<Game>>> GetGameById(string GameGUID)
        {
            var result = new ApiResult<Game>();
            try
            {
                result.Data = await _gameService.GetGameById(GameGUID);
                return Ok(result);
            }
            catch (GenericBusinessException ex)
            {
                result.AddError(ex.Message, "GenericBusinessError");
                _logger.LogError(ex, $"GetAllGames -->: {ex.Message}");
                return new ObjectResult(result)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message, "TechnicalError");
                _logger.LogError(ex, $"GetAllGames -->: {ex.Message}");
                return new ObjectResult(result)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        //Create and use BattleshipPlacementRequest(gameGUID, playerGUID, battleshipGUID, Coordinates(x,y)) and BattleshipResponse
        [HttpPost("PositionBattleship")]
        public async Task<ActionResult<ApiResult<PositionBattleshipResponse>>> PositionBattleship(PositionBattleshipRequest request)
        {
            var result = new ApiResult<PositionBattleshipResponse>();
            try
            {
                result.Data = await _gameService.PositionBattleship(request);
                return Ok(result);
            }
            catch (GenericBusinessException ex)
            {
                result.AddError(ex.Message, "GenericBusinessError");
                _logger.LogError(ex, $"PositionBattleship -->: {ex.Message}");
                return new ObjectResult(result)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message, "TechnicalError");
                _logger.LogError(ex, $"PositionBattleship -->: {ex.Message}");
                return new ObjectResult(result)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }


    }
}