﻿using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;

namespace AiAdventure.Interfaces
{
    public interface IPlayerService
    {
        Task<Player> CreateAsync(PlayerCreationDto data);
        Task<Player>? GetByEmail(string email);
    }
}