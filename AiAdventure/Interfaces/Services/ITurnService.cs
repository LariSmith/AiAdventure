using AiAdventure.Domain.Entities;
using Newtonsoft.Json.Linq;

namespace AiAdventure.Interfaces.Services
{
    public interface ITurnService
    {
        void CreateTurn(JObject turnJson, Character character);
    }
}
