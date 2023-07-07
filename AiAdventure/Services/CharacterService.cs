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
            var model = JsonParse.ParseCharacterModel(characterJson);
            model.Json = characterJson.ToString();

            var character = player.GenerateCharacter(model);

            AddSkill((JObject)characterJson["data"]["skills"], character);
            AddFeature((JObject)characterJson["data"]["classFeatures"], character);
            AddProficiency((JObject)characterJson["data"]["proficiencies"], character);
            AddItem((JObject)characterJson["data"]["inventory"], character);

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

        public void AddSkill(JObject skillsJson, Character character)
        {
            foreach (var skill in skillsJson)
            {
                var skillName = skill.Key;
                var skillValue = skill.Value.Value<int>();

                character.AddSkill(skillName, skillValue);
            }
        }

        public void AddProficiency(JObject proficienciesJson, Character character)
        {
            foreach (var proficiency in proficienciesJson)
            {
                var proficiencyType = proficiency.Key;
                var proficiencyArray = (JArray)proficiency.Value;

                var proficiencyValues = string.Join(", ", proficiencyArray);

                character.AddProficiency(proficiencyType, proficiencyValues);
            }
        }

        public void AddFeature(JObject featureJson, Character character)
        {
            foreach (var feature in featureJson)
            {
                var featureName = feature.Key;
                var featureDescription = feature.Value.Value<string>();

                character.AddFeature(featureName, featureDescription);
            }
        }

        public void AddItem(JObject itemJson, Character character)
        {
            foreach (var item in itemJson)
            {
                var itemName = item.Key;
                var itemQuantity = item.Value.Value<int>();

                character.AddItem(itemName, itemQuantity);
            }
        }
    }
}
