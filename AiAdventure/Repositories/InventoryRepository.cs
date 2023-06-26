﻿using AiAdventure.Data;
using AiAdventure.Domain.Entities;
using AiAdventure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AiAdventure.Repositories
{
    public class InventoryRepository : RepositoryBase<Item>, IInventoryRepository
    {
        public InventoryRepository(AiAdventureContext context) : base(context)
        {
        }
    }
}
