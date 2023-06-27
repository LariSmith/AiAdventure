using AiAdventure.Data;
using AiAdventure.Interfaces;

namespace AiAdventure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AiAdventureContext _context;

        public IPlayerRepository Players { get; }

        public ICharacterRepository Characters { get; }

        public IProficiencyRepository Proficiencies { get; }

        public ISkillRepository Skills { get; }

        public IFeatureRepository Features { get; }

        public IInventoryRepository Inventory { get; }

        public UnitOfWork(AiAdventureContext context, IPlayerRepository players, 
                          ICharacterRepository characters, IProficiencyRepository proficiencies, 
                          ISkillRepository skills, IFeatureRepository features, IInventoryRepository inventory) 
        {
            _context = context;
            Players = players ?? throw new ArgumentNullException(nameof(players));
            Characters = characters ?? throw new ArgumentNullException(nameof(characters));
            Proficiencies = proficiencies ?? throw new ArgumentNullException(nameof(proficiencies));
            Skills = skills ?? throw new ArgumentNullException(nameof(skills));
            Features = features ?? throw new ArgumentNullException(nameof(features));
            Inventory = inventory ?? throw new ArgumentException(nameof(inventory));
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
