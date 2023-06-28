using AiAdventure.Domain.Entities;

namespace AiAdventure.Interfaces.Repositories
{
    public interface ICharacterRepository : IRepositoryBase<Character>
    {
        Task<IEnumerable<Character>> GetAll(int playerId);
    }
}
