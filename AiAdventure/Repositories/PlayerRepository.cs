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

        public Player GetByEmail(string email)
        {
            return _dbSet.FirstOrDefault(x => x.Email == email);
        }
    }
}
