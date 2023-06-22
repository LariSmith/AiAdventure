using AiAdventure.Domain.Entities;
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

        public Player Create(PlayerCreationDto data)
        {
            var encryptPassword = _passwordHandler.Encrypt(data.Password);
            var player = Player.Create(Guid.NewGuid(), data.Email, encryptPassword, data.Name);
            _unitOfWork.Players.Add(player);
            _unitOfWork.Commit();

            return player;
        }

        public Player? GetByEmail(string email)
        {
            var searchPlayer = _unitOfWork.Players.GetByEmail(email);
            return searchPlayer;
        }
    }
}
