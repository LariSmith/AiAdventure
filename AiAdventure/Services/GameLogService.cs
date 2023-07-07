using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;
using AiAdventure.Interfaces;
using AiAdventure.Interfaces.Services;
using AutoMapper;

namespace AiAdventure.Services
{
    public class GameLogService : IGameLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GameLogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void SaveGameLog(int characterId, string action)
        {
        }

        public async Task<List<GameLogDto>> GetAllGameLogs(int characterId)
        {
            var logs = await _unitOfWork.GameLog.GetAllLogForCharacter(characterId);
            var logsDto = new List<GameLogDto>();

            foreach (var log in logs)
            {
                var logDto = _mapper.Map<GameLogDto>(log);
                logsDto.Add(logDto);
            }

            return logsDto;
        }
    }
}
