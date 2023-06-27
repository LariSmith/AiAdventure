using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;
using System.IdentityModel.Tokens.Jwt;

namespace AiAdventure.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<Player> Authenticate(LoginDto data);
        JwtSecurityToken GenerateToken(Player player);
    }
}
