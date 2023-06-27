using AiAdventure.Interfaces;
using Newtonsoft.Json.Linq;

namespace AiAdventure.Utilities
{
    public class JsonHandler
    {
        public static T GetTokenValue<T>(JObject json, string path)
        {
            JToken token = json.SelectToken(path);
            return token != null ? token.Value<T>() : default;
        }
    }
}
