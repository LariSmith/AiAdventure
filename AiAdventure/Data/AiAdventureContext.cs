using AiAdventure.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AiAdventure.Data
{
    public class AiAdventureContext : DbContext
    {
        public AiAdventureContext(DbContextOptions options) : base(options) { }

        public DbSet<Character> Characters => Set<Character>();
    }
}
