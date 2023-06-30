using Newtonsoft.Json.Linq;

namespace AiAdventure.Interfaces.Services
{
    public interface IChatService
    {
        Task<JObject> GenerateCharacterJson();
        Task<JObject> GenerateTurn(string character);
    }
}
