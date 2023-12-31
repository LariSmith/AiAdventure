﻿using AiAdventure.DTOs;
using AiAdventure.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AiAdventure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Player")]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        [Route("new-game")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CharacterDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> StartGame([FromForm]bool testOnly = false)
        {
            try
            {
                int playerId;

                if (!int.TryParse(User.FindFirst("sid")?.Value, out playerId))
                    return Unauthorized();

                var model = await _gameService.CreateNewGame(playerId, testOnly);
                
                return Ok(model);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("next-turn")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CharacterDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<ActionResult> NextTurn(int characterId, string command, bool testOnly = false)
        {
            try
            {
                int playerId;

                if (!int.TryParse(User.FindFirst("sid")?.Value, out playerId))
                    return Unauthorized();

                var model = await _gameService.CreateNextTurn(characterId, command, testOnly);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
