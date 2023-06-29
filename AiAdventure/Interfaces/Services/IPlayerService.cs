using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;

namespace AiAdventure.Interfaces.Services
{
    public interface IPlayerService
    {
        Task<PlayerDto> CreateAsync(PlayerCreationDto data);
        Task<PlayerDto>? GetByEmail(string email);
        Task<PlayerDto> GetPlayerInfo(int id);
    }
}
