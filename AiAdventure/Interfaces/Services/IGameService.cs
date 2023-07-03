using AiAdventure.DTOs;

namespace AiAdventure.Interfaces.Services
{
    public interface IGameService
    {
        Task<CharacterDto> CreateNewGame(int playerId);
    }
}
