using AiAdventure.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AiAdventure.Data
{
    public class AiAdventureContext : IdentityDbContext<IdentityUser>
    {
        public AiAdventureContext(DbContextOptions<AiAdventureContext> options) : base(options) { }

        public DbSet<Player> Players => Set<Player>();
        public DbSet<Character> Characters => Set<Character>();
        public DbSet<Creature> Creatures => Set<Creature>();
        public DbSet<Feature> Features => Set<Feature>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<NPC> NPCs => Set<NPC>();
        public DbSet<Proficiency> Proficiencies => Set<Proficiency>();
        public DbSet<Quest> Questions => Set<Quest>();
        public DbSet<Skill> Skills => Set<Skill>();
        public DbSet<Treasure> treasures => Set<Treasure>();
        public DbSet<Turn> turns => Set<Turn>();
    }
}
