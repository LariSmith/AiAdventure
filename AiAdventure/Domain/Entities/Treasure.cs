namespace AiAdventure.Domain.Entities
{
    public class Treasure
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OriginalLocationId { get; set; }

        public Location OriginalLocation { get; set; }
    }
}
