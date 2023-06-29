using AiAdventure.DTOs;
using AiAdventure.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace AiAdventure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        private readonly IAuthenticationService _authService;

        public AuthenticateController(IAuthenticationService authentication)
        {
            _authService = authentication;
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticationResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> Login([FromForm] LoginDto data)
        {
            try
            {
                var player = await _authService.Authenticate(data);

                if (player == null) 
                    return NotFound();

                var token = _authService.GenerateToken(player);

                return Ok(new AuthenticationResponseDto
                {
                    PlayerId = player.Id.ToString(),
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
