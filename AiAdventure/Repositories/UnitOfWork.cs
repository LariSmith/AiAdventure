using AiAdventure.Data;
using AiAdventure.Interfaces;
using AiAdventure.Migrations;

namespace AiAdventure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AiAdventureContext _context;

        public IPlayerRepository Players { get; }

        public ICharacterRepository Characters { get; }

        public UnitOfWork(AiAdventureContext context, IPlayerRepository players) 
        {
            _context = context;
            Players = players ?? throw new ArgumentNullException(nameof(players));
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
