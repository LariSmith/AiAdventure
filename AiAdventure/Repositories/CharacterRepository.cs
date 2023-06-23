using AiAdventure.Data;
using AiAdventure.Domain.Entities;
using AiAdventure.Interfaces;

namespace AiAdventure.Repositories
{
    public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
    {
        public CharacterRepository(AiAdventureContext context) : base(context)
        { }
    }
}
