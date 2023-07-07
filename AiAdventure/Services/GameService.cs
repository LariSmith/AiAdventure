using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;
using AiAdventure.Interfaces;
using AiAdventure.Interfaces.Services;
using AutoMapper;
using Newtonsoft.Json.Linq;
using System.Text;

namespace AiAdventure.Services
{
    public class GameService : IGameService
    {
        private readonly IChatService _chatService;
        private readonly ICharacterService _characterService;
        private readonly ITurnService _turnService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGameLogService _gameLogService;
        private readonly IMapper _mapper;

        public GameService(IChatService chatService, ICharacterService characterService, ITurnService turnService, IUnitOfWork unitOfWork, IMapper mapper, IGameLogService gameLogService)
        {
            _chatService = chatService;
            _characterService = characterService;
            _turnService = turnService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _gameLogService = gameLogService;
        }

        public async Task<CharacterDto> CreateNewGame(int playerId, bool testOnly = false)
        {
            var characterJson = await _chatService.GenerateCharacterJson(testOnly);
            var turnJson = await _chatService.GenerateTurnJson(characterJson.ToString(), testOnly);

            var character = _characterService.CreateCharacter(characterJson, playerId);
            _turnService.CreateTurn(turnJson, character);
            character.AddLog("New game in Turn 1");

            using (var unitOfWork = _unitOfWork)
            {
                await unitOfWork.Characters.AddAsync(character);
                unitOfWork.Commit();
            }

            var characterDto = _mapper.Map<CharacterDto>(character);

            return characterDto;
        }

        public async Task<CharacterDto> CreateNextTurn(int characterId, string command, bool testOnly = false)
        {
            var character = await _unitOfWork.Characters.GetCharacterJoinTurnJoinLog(characterId);
            StringBuilder logs = new StringBuilder();

            foreach (var log  in character.GameLogs)
            {
                logs.AppendLine(log.Action);
            }

            var turnJson = await _chatService.GenerateNextTurnJson(character.Json, character.Turns.Last().Json, logs.ToString(), command, testOnly);

            _turnService.CreateTurn(turnJson, character);
            character.AddLog(command);

            using (var unitOfWork = _unitOfWork)
            {
                await unitOfWork.Characters.UpdateAsync(character);
                unitOfWork.Commit();
            }

            var characterDto = _mapper.Map<CharacterDto>(character);

            return characterDto;
        }
    }
}
