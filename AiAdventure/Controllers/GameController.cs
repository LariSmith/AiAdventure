using AiAdventure.DTOs;
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
                var playerId = int.Parse(User.FindFirst("sid")?.Value);

                if (playerId == null)
                    return Unauthorized();

                var model = await _gameService.CreateNewGame(playerId, testOnly);
                
                return Ok(model);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
