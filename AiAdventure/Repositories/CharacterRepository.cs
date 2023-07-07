using AiAdventure.Data;
using AiAdventure.Domain.Entities;
using AiAdventure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AiAdventure.Repositories
{
    public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
    {
        public CharacterRepository(AiAdventureContext context) : base(context)
        { }

        public async Task<IEnumerable<Character>> GetAll(int playerId)
        {
            return await _set.Where(x => x.PlayerId == playerId).ToListAsync();
        }

        public async Task<Character> GetCharacterJoinTurnJoinLog(int characterId)
        {
            return await _set.Where(x => x.Id == characterId).Include(x => x.Turns).Include(x => x.GameLogs).FirstAsync();
        }
    }
}
