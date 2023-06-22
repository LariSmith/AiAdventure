using AiAdventure.DTOs;
using AiAdventure.Interfaces;
using AiAdventure.Services;
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
        public IActionResult CreatePlayer([FromForm] PlayerCreationDto data)
        {
            try
            {
                if (_playerService.GetByEmail(data.Email) != null)
                    return Conflict();

                var player = _playerService.Create(data);

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
    }
}
