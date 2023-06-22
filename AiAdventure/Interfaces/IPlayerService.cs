using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;

namespace AiAdventure.Interfaces
{
    public interface IPlayerService
    {
        Player Create(PlayerCreationDto data);
        Player? GetByEmail(string email);
    }
}
