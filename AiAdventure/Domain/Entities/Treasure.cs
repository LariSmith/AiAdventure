namespace AiAdventure.Domain.Entities
{
    public class Treasure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OriginalLocationId { get; set; }

        public Location OriginalLocation { get; set; }
    }
}
