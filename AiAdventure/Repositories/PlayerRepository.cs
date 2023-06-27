using AiAdventure.Data;
using AiAdventure.Domain.Entities;
using AiAdventure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AiAdventure.Repositories
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(AiAdventureContext context) : base(context)
        { }

        public async Task<Player> GetByEmailAsync(string email)
        {
            return await _set.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
