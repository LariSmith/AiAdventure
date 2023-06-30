namespace AiAdventure.Domain.Entities
{
    public class Treasure
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int OriginalLocationId { get; private set; }

        internal Treasure(string name, string description, int originalLocationId)
        {
            Name = name;
            Description = description;
            OriginalLocationId = originalLocationId;
        }
    }
}
