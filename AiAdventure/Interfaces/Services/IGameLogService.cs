using AiAdventure.DTOs;

namespace AiAdventure.Interfaces.Services
{
    public interface IGameLogService
    {
        void SaveGameLog(int characterId, string action);
        Task<List<GameLogDto>> GetAllGameLogs(int characterId);
    }
}
