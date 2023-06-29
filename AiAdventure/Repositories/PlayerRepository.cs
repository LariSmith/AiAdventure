using AiAdventure.Data;
using AiAdventure.Domain.Entities;
using AiAdventure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AiAdventure.Repositories
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(AiAdventureContext context) : base(context)
        { }

        public async Task<Player?> GetByEmailAsync(string email)
        {
            return await _set.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Player?> GetPlayerInfo(int id) {
            return await _set.Where(x => x.Id == id)
                             .Include(x => x.Characters)
                                .ThenInclude(x => x.Skills)
                             .Include(x => x.Characters)
                                .ThenInclude(x => x.Items)
                             .Include(x => x.Characters)
                                .ThenInclude(x => x.Features)
                             .Include(x => x.Characters)
                                .ThenInclude(x => x.Proficiencies)
                             .FirstOrDefaultAsync();
        }
    }
}
