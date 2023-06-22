using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;

namespace AiAdventure.Interfaces
{
    public interface IPlayerService
    {
        Player Create(PlayerDto data);
        Player GetPlayer(int id);
    }
}
