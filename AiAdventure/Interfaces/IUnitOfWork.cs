namespace AiAdventure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayerRepository Players { get; }
        int Commit();
    }
}
