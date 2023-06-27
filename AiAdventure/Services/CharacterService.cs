using AiAdventure.Domain.Entities;
using AiAdventure.Interfaces;
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
            var name = JsonHandle.GetTokenValueString(characterJson, "data.name");
            var race = JsonHandle.GetTokenValueString(characterJson, "data.race");
            var gender = JsonHandle.GetTokenValueString(characterJson, "data.gender");
            var @class = JsonHandle.GetTokenValueString(characterJson, "data.class");
            var level = JsonHandle.GetTokenValueInt(characterJson, "data.level");
            var experience = JsonHandle.GetTokenValueFloat(characterJson, "data.experience");
            var maxExperience = JsonHandle.GetTokenValueFloat(characterJson, "data.maxExperience");
            var strength = JsonHandle.GetTokenValueInt(characterJson, "data.strength");
            var dexterity = JsonHandle.GetTokenValueInt(characterJson, "data.dexterity");
            var constitution = JsonHandle.GetTokenValueInt(characterJson, "data.Constitution");
            var intelligence = JsonHandle.GetTokenValueInt(characterJson, "data.Intelligence");
            var wisdom = JsonHandle.GetTokenValueInt(characterJson, "data.Wisdom");
            var charisma = JsonHandle.GetTokenValueInt(characterJson, "data.Charisma");
            var background = JsonHandle.GetTokenValueString(characterJson, "data.background");
            var hitpoints = JsonHandle.GetTokenValueInt(characterJson, "data.hitPoints");
            var armorClass = JsonHandle.GetTokenValueInt(characterJson, "data.armorClass");
            var health = JsonHandle.GetTokenValueInt(characterJson, "data.health");
            var gold = JsonHandle.GetTokenValueInt(characterJson, "data.gold");

            var player = await _unitOfWork.Players.GetByIdAsync(playerId);

            var character = player.GenerateCharacter(name, gender, race, @class, background, strength, dexterity, constitution, intelligence, wisdom, charisma, hitpoints, armorClass, health, gold, experience, maxExperience, level);

            var skillsObject = (JObject)characterJson["data"]["skills"];
            character = AddSkill(skillsObject, character);

            var featuresObject = (JObject)characterJson["data"]["classFeatures"];
            character = AddFeature(featuresObject, character);

            var proficienciesObject = (JObject)characterJson["data"]["proficiencies"];
            character = AddProficiency(proficienciesObject, character);

            var inventoryArray = (JObject)characterJson["data"]["inventory"];
            character = AddItem(inventoryArray, character);

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
