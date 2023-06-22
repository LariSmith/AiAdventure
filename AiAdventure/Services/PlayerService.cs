﻿using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;
using AiAdventure.Interfaces;

namespace AiAdventure.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHandler _passwordHandler;

        public PlayerService(IUnitOfWork unitOfWork, IPasswordHandler passwordHandler)
        {
            _unitOfWork = unitOfWork;
            _passwordHandler = passwordHandler;
        }

        public async Task<Player> CreateAsync(PlayerCreationDto data)
        {
            var encryptPassword = _passwordHandler.Encrypt(data.Password);
            var player = Player.Create(Guid.NewGuid(), data.Email, encryptPassword, data.Name);
            await _unitOfWork.Players.AddAsync(player);
            _unitOfWork.Commit();

            return player;
        }

        public async Task<Player>? GetByEmail(string email)
        {
            var searchPlayer = await _unitOfWork.Players.GetByEmailAsync(email);
            return searchPlayer;
        }
    }
}
