using AiAdventure.Interfaces.Repositories;

namespace AiAdventure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayerRepository Players { get; }
        ICharacterRepository Characters { get; }
        ISkillRepository Skills { get; }
        IFeatureRepository Features { get; }
        IInventoryRepository Inventory { get; }
        IProficiencyRepository Proficiencies { get; }
        IGameLogRepository GameLog { get; }
        int Commit();
    }
}
