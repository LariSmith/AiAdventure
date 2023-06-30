using AiAdventure.Domain.Entities;
using Newtonsoft.Json.Linq;

namespace AiAdventure.Interfaces.Services
{
    public interface ICharacterService
    {
        Character CreateCharacter(JObject character, int playerId);
        Task<Character> GetCharacter(int characterId);
        Task<IEnumerable<Character>> GetAllCharacters(int playerId);
        void AddSkill(JToken skillsJson, Character character);
        void AddProficiency(JToken proficienciesJson, Character character);
        void AddFeature(JToken featureJson, Character character);
        void AddItem(JToken itemJson, Character character);
    }
}
