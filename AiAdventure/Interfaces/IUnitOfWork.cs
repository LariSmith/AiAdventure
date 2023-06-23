namespace AiAdventure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayerRepository Players { get; }
        ICharacterRepository Characters { get; }
        int Commit();
    }
}
