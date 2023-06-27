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

        public async Task<Character> CreateCharacter(JObject characterJson, int playerId)
        {
            var player = await _unitOfWork.Players.GetByIdAsync(playerId);
            var character = player.GenerateCharacter(JsonParse.ParseCharacterModel(characterJson));

            character = AddSkill((JObject)characterJson["data"]["skills"], character);
            character = AddFeature((JObject)characterJson["data"]["classFeatures"], character);
            character = AddProficiency((JObject)characterJson["data"]["proficiencies"], character);
            character = AddItem((JObject)characterJson["data"]["inventory"], character);

            using (var unitOfWork = _unitOfWork)
            {
                await _unitOfWork.Characters.AddAsync(character);
                _unitOfWork.Commit();
            }

            return character;
        }

        public Character AddSkill(JObject skillsJson, Character character)
        {
            foreach (var skill in skillsJson)
            {
                var skillName = skill.Key;
                var skillValue = skill.Value.Value<int>();

                character.AddSkill(skillName, skillValue);
            }

            return character;
        }

        public Character AddProficiency(JObject proficienciesJson, Character character)
        {
            foreach (var proficiency in proficienciesJson)
            {
                var proficiencyType = proficiency.Key;
                var proficiencyArray = (JArray)proficiency.Value;

                var proficiencyValues = string.Join(", ", proficiencyArray);

                character.AddProficiency(proficiencyType, proficiencyValues);
            }

            return character;
        }

        public Character AddFeature(JObject featureJson, Character character)
        {
            foreach (var feature in featureJson)
            {
                var featureName = feature.Key;
                var featureDescription = feature.Value.Value<string>();

                character.AddFeature(featureName, featureDescription);
            }

            return character;
        }

        public Character AddItem(JObject itemJson, Character character)
        {
            foreach (var item in itemJson)
            {
                var itemName = item.Key;
                var itemQuantity = item.Value.Value<int>();

                character.AddItem(itemName, itemQuantity);
            }

            return character;
        }
    }
}
