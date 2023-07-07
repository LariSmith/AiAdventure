using Newtonsoft.Json.Linq;

namespace AiAdventure.Interfaces.Services
{
    public interface IChatService
    {
        Task<JObject> GenerateCharacterJson(bool testOnly = false);
        Task<JObject> GenerateTurnJson(string character, bool testOnly = false);
        Task<JObject> GenerateNextTurnJson(string characterJson, string lastTurnJson, string gameLog, string command, bool testOnly = false);
    }
}
