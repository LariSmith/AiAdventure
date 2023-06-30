using AiAdventure.Domain.Entities;
using AiAdventure.Domain.Models;
using AiAdventure.Interfaces;
using AiAdventure.Interfaces.Services;
using AiAdventure.Utilities;
using Newtonsoft.Json.Linq;
using System.Text;

namespace AiAdventure.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CharacterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Character CreateCharacter(JObject characterJson, int playerId)
        {
            var player = _unitOfWork.Players.GetById(playerId);
            var character = player.GenerateCharacter(JsonParse.ParseCharacterModel(characterJson));

            AddSkill(characterJson["data"]["skills"], character);
            AddFeature(characterJson["data"]["classFeatures"], character);
            AddProficiency(characterJson["data"]["proficiencies"], character);
            AddItem(characterJson["data"]["inventory"], character);

            return character;
        }

        public async Task<Character> GetCharacter(int characterId)
        {
            return await _unitOfWork.Characters.GetByIdAsync(characterId);
        }

        public async Task<IEnumerable<Character>> GetAllCharacters(int playerId)
        {
            return await _unitOfWork.Characters.GetAll(playerId);
        }

        public void AddSkill(JToken skillsJson, Character character)
        {
            foreach (var skill in skillsJson)
            {
                var skillName = skill.Path;
                var skillValue = skill.Value<int>();

                character.AddSkill(skillName, skillValue);
            }
        }

        public void AddProficiency(JToken proficienciesJson, Character character)
        {
            foreach (var proficiency in proficienciesJson)
            {
                var proficiencyType = proficiency.Path;
                var proficiencyArray = proficiency.Value<JArray>();

                var proficiencyValues = string.Join(", ", proficiencyArray);

                character.AddProficiency(proficiencyType, proficiencyValues);
            }
        }

        public void AddFeature(JToken featureJson, Character character)
        {
            foreach (var feature in featureJson)
            {
                var featureName = feature.Path;
                var featureDescription = feature.Value<string>();

                character.AddFeature(featureName, featureDescription);
            }
        }

        public void AddItem(JToken itemJson, Character character)
        {
            foreach (var item in itemJson)
            {
                var itemName = item.Path;
                var itemQuantity = item.Value<int>();

                character.AddItem(itemName, itemQuantity);
            }
        }
    }
}
