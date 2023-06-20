namespace AiAdventure.Domain.Entities
{
    public class Proficiency
    {
        public Guid Id { get; set; }
        public Guid CharacterId { get; set; }
        public string Type { get; set; }
        public string List { get; set; }

        public Character Character { get; set; }
    }
}
