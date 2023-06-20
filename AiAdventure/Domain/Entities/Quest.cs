namespace AiAdventure.Domain.Entities
{
    public class Quest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Guid OriginalLocationId { get; set; }

        public Location OriginalLocation { get; set; }
    }
}
