﻿using AiAdventure.Data;
using AiAdventure.Domain.Entities;
using AiAdventure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AiAdventure.Repositories
{
    public class FeatureRepository : RepositoryBase<Feature>, IFeatureRepository
    {
        public FeatureRepository(AiAdventureContext context) : base(context)
        {
        }
    }
}
