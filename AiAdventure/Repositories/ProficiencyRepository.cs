﻿using AiAdventure.Data;
using AiAdventure.Domain.Entities;
using AiAdventure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AiAdventure.Repositories
{
    public class ProficiencyRepository : RepositoryBase<Proficiency>, IProficiencyRepository
    {
        public ProficiencyRepository(AiAdventureContext context) : base(context)
        {
        }
    }
}
