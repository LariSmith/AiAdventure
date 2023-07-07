using AiAdventure.Data;
using AiAdventure.Domain.Entities;
using AiAdventure.Interfaces.Repositories;

namespace AiAdventure.Repositories
{
    public class GameLogRepository : RepositoryBase<GameLog>, IGameLogRepository
    {
        public GameLogRepository(AiAdventureContext context) : base(context)
        { }

        public Task<IEnumerable<GameLog>> GetAllLogForCharacter(int characterId)
        {
            return FindAsync(x => x.CharacterId == characterId);
        } 
    }
}
