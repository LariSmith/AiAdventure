using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;
using AiAdventure.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AiAdventure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHandler _passwordHandler;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IUnitOfWork unitOfWork, IPasswordHandler passwordHandler, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _passwordHandler = passwordHandler;
            _configuration = configuration;
        }

        public async Task<Player> Authenticate(LoginDto data)
        {
            var player = await _unitOfWork.Players.GetByEmailAsync(data.Email);

            if (player == null)
                return null;

            var verifyPassword = _passwordHandler.VerifyPassword(data.Password, player.Password);

            if (!verifyPassword)
                return null;

            return player;
        }

        public JwtSecurityToken GenerateToken(Player player)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var host = _configuration["ApplicationSettings:Host"];
            var expiration = int.Parse(_configuration["JWT:TokenValidity"]);

            var claims = new List<Claim>
            {
                new Claim("name", player.Name),
                new Claim("role", "Player"),
                new Claim("sid", player.Id.ToString())
            };

            var identity = new ClaimsIdentity(claims);
            var principal = new ClaimsPrincipal(identity);
            Thread.CurrentPrincipal = principal;

            return new JwtSecurityToken(
                issuer: host,
                audience: host,
                claims: claims,
                expires: DateTime.Now.AddHours(expiration),
                signingCredentials: signinCredentials
            );
        }
    }
}
