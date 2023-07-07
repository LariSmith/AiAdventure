using AiAdventure.Domain.Entities;
using AiAdventure.Interfaces.Services;
using AiAdventure.Utilities;
using Newtonsoft.Json.Linq;

namespace AiAdventure.Services
{
    public class TurnService : ITurnService
    {
        public void CreateTurn(JObject turnJson, Character character)
        {
            var model = JsonParse.ParseTurnModel(turnJson);
            var commands = String.Join(",", model.Commands);

            character.AddTurn(model.Number, model.Weather, model.Scene, model.CurrentDay, model.PeriodDay, commands, turnJson.ToString());
        }

    }
}
