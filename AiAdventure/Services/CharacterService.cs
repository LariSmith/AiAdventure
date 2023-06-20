using AiAdventure.Domain.Entities;
using AiAdventure.Interfaces;
using Newtonsoft.Json.Linq;
using System.Text;

namespace AiAdventure.Services
{
    public class CharacterService : ICharacterService
    {

        public Character Create(JObject character)
        {
            var name = JsonHandle.GetTokenValueString(character, "data.name");
            var race = JsonHandle.GetTokenValueString(character, "data.race");
            var gender = JsonHandle.GetTokenValueString(character, "data.gender");
            var @class = JsonHandle.GetTokenValueString(character, "data.class");
            var level = JsonHandle.GetTokenValueInt(character, "data.level");
            var experience = JsonHandle.GetTokenValueFloat(character, "data.experience");
            var maxExperience = JsonHandle.GetTokenValueFloat(character, "data.maxExperience");
            var strength = JsonHandle.GetTokenValueInt(character, "data.strength");
            var dexterity = JsonHandle.GetTokenValueInt(character, "data.dexterity");
            var constitution = JsonHandle.GetTokenValueInt(character, "data.Constitution");
            var intelligence = JsonHandle.GetTokenValueInt(character, "data.Intelligence");
            var wisdom = JsonHandle.GetTokenValueInt(character, "data.Wisdom");
            var charisma = JsonHandle.GetTokenValueInt(character, "data.Charisma");
            var background = JsonHandle.GetTokenValueString(character, "data.background");
            var hitpoints = JsonHandle.GetTokenValueInt(character, "data.hitPoints");
            var armorClass = JsonHandle.GetTokenValueInt(character, "data.armorClass");
            var health = JsonHandle.GetTokenValueInt(character, "data.health");

            var newCharacter = Character.Create(Guid.NewGuid(), name, gender, race, @class, background, strength, dexterity, constitution, intelligence, wisdom, charisma, hitpoints, armorClass, health, experience, maxExperience, level);

            var skillsObject = (JObject)character["data"]["skills"];

            foreach (var skill in skillsObject)
            {
                var skillName = skill.Key;
                var skillValue = skill.Value.Value<int>();

                newCharacter.AddSkill(skillName, skillValue);
            }

            var featuresObject = (JObject)character["data"]["classFeatures"];

            foreach (var feature in featuresObject)
            {
                var featureName = feature.Key;
                var featureDescription = feature.Value.Value<string>();

                newCharacter.AddFeature(featureName, featureDescription);
            }

            var proficienciesObject = (JObject)character["data"]["proficiencies"];

            foreach (var proficiency in proficienciesObject)
            {
                var proficiencyType = proficiency.Key;
                var proficiencyArray = (JArray)proficiency.Value;

                var proficiencyValues = string.Join(", ", proficiencyArray);

                newCharacter.AddProficiency(proficiencyType, proficiencyValues);
            }

            var inventoryArray = (JObject)character["data"]["inventory"];

            foreach (var item in inventoryArray)
            {
                var itemName = item.Key;
                var itemQuantity = item.Value.Value<int>();

                newCharacter.AddItem(itemName, itemQuantity);
            }

            return newCharacter;
        }
    }
}
