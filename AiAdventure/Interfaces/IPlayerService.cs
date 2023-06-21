using AiAdventure.Domain.Entities;

namespace AiAdventure.Interfaces
{
    public interface IPlayerService
    {
        Player Create(string email, string password);
    }
}
