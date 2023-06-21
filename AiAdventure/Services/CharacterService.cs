using AiAdventure.Domain.Entities;
using AiAdventure.Interfaces;
using Newtonsoft.Json.Linq;
using System.Text;

namespace AiAdventure.Services
{
    public class CharacterService : ICharacterService
    {

        public Character Create(JObject characterJson, Player player)
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

            var character = player.GenerateCharacter(Guid.NewGuid(), name, gender, race, @class, background, strength, dexterity, constitution, intelligence, wisdom, charisma, hitpoints, armorClass, health, gold, experience, maxExperience, level);

            var skillsObject = (JObject)characterJson["data"]["skills"];

            foreach (var skill in skillsObject)
            {
                var skillName = skill.Key;
                var skillValue = skill.Value.Value<int>();

                character.AddSkill(skillName, skillValue);
            }

            var featuresObject = (JObject)characterJson["data"]["classFeatures"];

            foreach (var feature in featuresObject)
            {
                var featureName = feature.Key;
                var featureDescription = feature.Value.Value<string>();

                character.AddFeature(featureName, featureDescription);
            }

            var proficienciesObject = (JObject)characterJson["data"]["proficiencies"];

            foreach (var proficiency in proficienciesObject)
            {
                var proficiencyType = proficiency.Key;
                var proficiencyArray = (JArray)proficiency.Value;

                var proficiencyValues = string.Join(", ", proficiencyArray);

                character.AddProficiency(proficiencyType, proficiencyValues);
            }

            var inventoryArray = (JObject)characterJson["data"]["inventory"];

            foreach (var item in inventoryArray)
            {
                var itemName = item.Key;
                var itemQuantity = item.Value.Value<int>();

                character.AddItem(itemName, itemQuantity);
            }

            return character;
        }
    }
}
