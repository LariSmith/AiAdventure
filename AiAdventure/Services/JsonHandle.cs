using AiAdventure.Interfaces;
using Newtonsoft.Json.Linq;

namespace AiAdventure.Services
{
    public class JsonHandle
    {
        public static string GetTokenValueString(JObject json, string path)
        {
            JToken token = json.SelectToken(path);
            return token != null ? token.Value<string>() : default(string);
        }

        public static int GetTokenValueInt(JObject json, string path)
        {
            JToken token = json.SelectToken(path);
            return token != null ? token.Value<int>() : default(int);
        }

        public static float GetTokenValueFloat(JObject json, string path)
        {
            JToken token = json.SelectToken(path);
            return token != null ? token.Value<float>() : default(float);
        }
    }
}
