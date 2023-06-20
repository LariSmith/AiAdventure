namespace AiAdventure.Domain.Entities
{
    public class Feature
    {
        public Guid Id { get; set; }
        public Guid CharacterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Character Character { get; set; }

    }
}
