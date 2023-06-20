using AiAdventure.Domain.Entities;
using AiAdventure.Interfaces;
using Newtonsoft.Json.Linq;

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
            var strength = JsonHandle.GetTokenValueInt(character, "data.strenght");
            var dexterity = JsonHandle.GetTokenValueInt(character, "data.dexterity");
            var constitution = JsonHandle.GetTokenValueInt(character, "data.constiturion");
            var intelligence = JsonHandle.GetTokenValueInt(character, "data.intelligence");
            var wisdom = JsonHandle.GetTokenValueInt(character, "data.wisdom");
            var charisma = JsonHandle.GetTokenValueInt(character, "data.charisma");
            var background = JsonHandle.GetTokenValueString(character, "data.background");
            var hitpoints = JsonHandle.GetTokenValueInt(character, "data.hitpoints");
            var armorClass = JsonHandle.GetTokenValueInt(character, "data.armorClass");
            var health = JsonHandle.GetTokenValueInt(character, "data.health");

            var newCharacter = Character.Create(Guid.NewGuid(), name, gender, race, @class, background, strength, dexterity, constitution, intelligence, wisdom, charisma, hitpoints, armorClass, health, experience, maxExperience, level);

            var skillsObject = (JObject)character["skills"];

            foreach (var skill in skillsObject)
            {
                var skillName = skill.Key;
                var skillValue = skill.Value.Value<int>();

                newCharacter.AddSkill(skillName, skillValue);
            }

            var featuresObject = (JObject)character["classFeatures"];

            foreach (var feature in featuresObject)
            {
                var featureName = feature.Key;
                var featureDescription = feature.Value.Value<string>();

                newCharacter.AddFeature(featureName, featureDescription);
            }

            var proficienciesObject = (JObject)character["proficiencies"];

            foreach (var proficiency in proficienciesObject)
            {
                var proficiencyType = proficiency.Key;
                var proficiencyList = proficiency.Value.Value<string>();

                newCharacter.AddProficiency(proficiencyType, proficiencyList);
            }

            var inventoryArray = (JArray)character["inventory"];

            foreach (var item in inventoryArray)
            {
                var itemName = item.Value<string>();

                newCharacter.AddItem(itemName, 1);
            }

            return newCharacter;
        }
    }
}
