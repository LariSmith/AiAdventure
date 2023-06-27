using AiAdventure.Domain.Entities;

namespace AiAdventure.Interfaces.Repositories
{
    public interface IPlayerRepository : IRepositoryBase<Player>
    {
        Task<Player> GetByEmailAsync(string email);
    }
}
