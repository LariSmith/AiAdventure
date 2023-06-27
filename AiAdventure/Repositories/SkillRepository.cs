using AiAdventure.Data;
using AiAdventure.Domain.Entities;
using AiAdventure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AiAdventure.Repositories
{
    public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
    {
        public SkillRepository(AiAdventureContext context) : base(context)
        {
        }
    }
}
