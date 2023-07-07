using AiAdventure.DTOs;

namespace AiAdventure.Interfaces.Services
{
    public interface IGameService
    {
        Task<CharacterDto> CreateNewGame(int playerId, bool testOnly = false);
        Task<CharacterDto> CreateNextTurn(int characterId, string command, bool testOnly = false);
    }
}
