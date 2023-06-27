namespace AiAdventure.Domain.Entities
{
    public class Feature
    {
        public int Id { get; private set; }
        public int CharacterId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        internal Feature(int characterId, string name, string description)
        {
            CharacterId = characterId;
            Name = name;
            Description = description;
        }

    }
}
