namespace AiAdventure.Domain.Entities
{
    public class Feature
    {
        public Guid Id { get; private set; }
        public Guid CharacterId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Character Character { get; private set; }

        internal Feature(Guid id, Guid characterId, string name, string description)
        {
            Id = id;
            CharacterId = characterId;
            Name = name;
            Description = description;
        }

    }
}
