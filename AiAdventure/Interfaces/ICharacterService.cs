using AiAdventure.Domain.Entities;
using Newtonsoft.Json.Linq;

namespace AiAdventure.Interfaces
{
    public interface ICharacterService
    {
        Character Create(JObject character, Guid playerId);
    }
}
