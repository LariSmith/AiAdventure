namespace AiAdventure.Domain.Entities
{
    public class Skill
    {
        public Guid Id { get; private set; }
        public Guid CharacterId { get; private set; }
        public string Description { get; private set; }
        public int Points { get; private set; }

        public Character Character { get; private set; }

        internal Skill(Guid id, Guid characterId, string description, int poins)
        {
            Id = id;
            CharacterId = characterId;
            Description = description;
            Points = poins;
        }
    }
}
