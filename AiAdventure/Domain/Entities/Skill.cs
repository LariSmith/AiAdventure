namespace AiAdventure.Domain.Entities
{
    public class Skill
    {
        public Guid Id { get; set; }
        public Guid CharacterId { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }

        public Character Character { get; set; }
    }
}
