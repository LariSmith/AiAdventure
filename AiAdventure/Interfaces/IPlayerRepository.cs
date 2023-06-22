using AiAdventure.Domain.Entities;

namespace AiAdventure.Interfaces
{
    public interface IPlayerRepository : IRepositoryBase<Player>
    {
        Player GetByEmail(string email);
    }
}
