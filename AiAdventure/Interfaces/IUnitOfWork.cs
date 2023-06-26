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
        int Commit();
    }
}
