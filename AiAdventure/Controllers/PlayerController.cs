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
        public IActionResult CreatePlayer(PlayerDto data)
        {
            try
            {
                var player = _playerService.Create(data);

                if (player == null) 
                    return NoContent();

                string playerUri = "/api/Player/" + player.Id;
                return Created(playerUri, player);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPlayer(int id)
        {
            try
            {
                var player = _playerService.GetPlayer(id);

                if (player == null)
                    return NotFound();

                return Ok(player);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
