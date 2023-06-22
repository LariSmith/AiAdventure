using AiAdventure.Domain.Entities;

namespace AiAdventure.Interfaces
{
    public interface IPlayerRepository : IRepositoryBase<Player>
    {
        Task<Player> GetByEmailAsync(string email);
    }
}
