namespace AiAdventure.Domain.Entities
{
    public class Quest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int OriginalLocationId { get; set; }

        public Location OriginalLocation { get; set; }
    }
}
