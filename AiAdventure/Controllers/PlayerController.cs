using AiAdventure.DTOs;
using AiAdventure.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AiAdventure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost]
        [Route("new-player")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlayerReturnDto))]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CreatePlayer([FromForm] PlayerCreationDto data)
        {
            try
            {
                var searchPlayer = await _playerService.GetByEmail(data.Email);

                if (searchPlayer != null)
                    return Conflict();

                var player = await _playerService.CreateAsync(data);

                var dto = new PlayerReturnDto()
                {
                    Email = player.Email,
                    Name = player.Name
                };

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Player")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlayerDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetInfoPlayer(int id)
        {
            try
            {
                var searchPlayer = await _playerService.GetPlayerInfo(id);

                if (searchPlayer == null)
                    return NoContent();

                return Ok(searchPlayer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
