using AiAdventure.Domain.Entities;
using Newtonsoft.Json.Linq;

namespace AiAdventure.Interfaces.Services
{
    public interface ICharacterService
    {
        Character CreateCharacter(JObject character, int playerId);
        Task<Character> GetCharacter(int characterId);
        Task<IEnumerable<Character>> GetAllCharacters(int playerId);
        void AddSkill(JObject skillsJson, Character character);
        void AddProficiency(JObject proficienciesJson, Character character);
        void AddFeature(JObject featureJson, Character character);
        void AddItem(JObject itemJson, Character character);
    }
}
