using AiAdventure.Domain.Models;
using AiAdventure.DTOs;
using Newtonsoft.Json.Linq;

namespace AiAdventure.Utilities
{
    public class JsonParse
    {
        public static CharacterModel ParseCharacterModel(JObject characterJson)
        {
            var characterModel = new CharacterModel
            {
                Name = JsonHandler.GetTokenValue<string>(characterJson, "data.name"),
                Race = JsonHandler.GetTokenValue<string>(characterJson, "data.race"),
                Gender = JsonHandler.GetTokenValue<string>(characterJson, "data.gender"),
                Class = JsonHandler.GetTokenValue<string>(characterJson, "data.class"),
                Level = JsonHandler.GetTokenValue<int>(characterJson, "data.level"),
                Experience = JsonHandler.GetTokenValue<int>(characterJson, "data.experience"),
                MaxExperience = JsonHandler.GetTokenValue<int>(characterJson, "data.maxExperience"),
                Strength = JsonHandler.GetTokenValue<int>(characterJson, "data.strength"),
                Dexterity = JsonHandler.GetTokenValue<int>(characterJson, "data.dexterity"),
                Constitution = JsonHandler.GetTokenValue<int>(characterJson, "data.Constitution"),
                Intelligence = JsonHandler.GetTokenValue<int>(characterJson, "data.Intelligence"),
                Wisdom = JsonHandler.GetTokenValue<int>(characterJson, "data.Wisdom"),
                Charisma = JsonHandler.GetTokenValue<int>(characterJson, "data.Charisma"),
                Background = JsonHandler.GetTokenValue<string>(characterJson, "data.background"),
                HitPoints = JsonHandler.GetTokenValue<int>(characterJson, "data.hitPoints"),
                ArmorClass = JsonHandler.GetTokenValue<int>(characterJson, "data.armorClass"),
                Health = JsonHandler.GetTokenValue<int>(characterJson, "data.health"),
                Gold = JsonHandler.GetTokenValue<int>(characterJson, "data.gold"),
            };

            return characterModel;
        }

        public static TurnModel ParseTurnModel(JObject turnJson)
        {
            var turnModel = new TurnModel
            {
                Number = JsonHandler.GetTokenValue<int>(turnJson, "data.number"),
                CurrentDay = JsonHandler.GetTokenValue<int>(turnJson, "data.currentDay"),
                PeriodDay = JsonHandler.GetTokenValue<string>(turnJson, "data.periodDay"),
                Scene = JsonHandler.GetTokenValue<string>(turnJson, "data.scene"),
                Weather = JsonHandler.GetTokenValue<string>(turnJson, "data.weather")
            };

            return turnModel;
        }

        public static GenericModel ParseGenericModel(JObject genericJson, string nameType)
        {
            var genericModel = new GenericModel
            {
                Name = JsonHandler.GetTokenValue<string>(genericJson, $"data.{nameType}.name"),
                Description = JsonHandler.GetTokenValue<string>(genericJson, $"data.{nameType}.description")
            };

            return genericModel;
        }
    }
}
