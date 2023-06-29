using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;
using AiAdventure.Interfaces;
using AiAdventure.Interfaces.Services;
using AiAdventure.Mappers;
using AiAdventure.Repositories;
using AutoMapper;
using System.Numerics;

namespace AiAdventure.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordService _passwordHandler;
        private readonly IMapper _mapper;

        public PlayerService(IUnitOfWork unitOfWork, IPasswordService passwordHandler, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _passwordHandler = passwordHandler;
            _mapper = mapper;
        }

        public async Task<PlayerDto> CreateAsync(PlayerCreationDto data)
        {
            using (var unitOfWork = _unitOfWork)
            {
                var encryptPassword = _passwordHandler.Encrypt(data.Password);
                var player = Player.Create(data.Email, encryptPassword, data.Name);
                await unitOfWork.Players.AddAsync(player);
                unitOfWork.Commit();

                return _mapper.Map<PlayerDto>(player);
            }
        }

        public async Task<PlayerDto>? GetByEmail(string email)
        {
            var searchPlayer = await _unitOfWork.Players.GetByEmailAsync(email);
            return _mapper.Map<PlayerDto>(searchPlayer);
        }

        public async Task<PlayerDto> GetPlayerInfo(int id)
        {
            var searchPlayer = await _unitOfWork.Players.GetPlayerInfo(id);
            return _mapper.Map<PlayerDto>(searchPlayer);
        }
    }
}
