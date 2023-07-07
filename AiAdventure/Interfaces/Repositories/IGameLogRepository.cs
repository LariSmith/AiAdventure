using AiAdventure.Domain.Entities;

namespace AiAdventure.Interfaces.Repositories
{
    public interface IGameLogRepository : IRepositoryBase<GameLog>
    {
        Task<IEnumerable<GameLog>> GetAllLogForCharacter(int characterId);
    }
}
