using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;
using AiAdventure.Interfaces;
using AiAdventure.Interfaces.Services;
using AutoMapper;
using Newtonsoft.Json.Linq;

namespace AiAdventure.Services
{
    public class GameService : IGameService
    {
        private readonly IChatService _chatService;
        private readonly ICharacterService _characterService;
        private readonly ITurnService _turnService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GameService(IChatService chatService, ICharacterService characterService, ITurnService turnService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _chatService = chatService;
            _characterService = characterService;
            _turnService = turnService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CharacterDto> CreateNewGame(int playerId, bool testOnly = false)
        {
            var characterJson = await _chatService.GenerateCharacterJson(testOnly);
            var turnJson = await _chatService.GenerateTurnJson(characterJson.ToString(), testOnly);

            var character = _characterService.CreateCharacter(characterJson, playerId);
            _turnService.CreateTurn(turnJson, character);

            using (var unitOfWork = _unitOfWork)
            {
                await unitOfWork.Characters.AddAsync(character);
                unitOfWork.Commit();
            }

            var characterDto = _mapper.Map<CharacterDto>(character);

            return characterDto;
        }
    }
}
