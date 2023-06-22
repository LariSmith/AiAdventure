using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;
using AiAdventure.Interfaces;

namespace AiAdventure.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Player Create(PlayerDto data)
        {
            throw new NotImplementedException();
        }

        public Player GetPlayer(int id) 
        {
            throw new NotImplementedException();
        }
    }
}
