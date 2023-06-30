namespace AiAdventure.Domain.Entities
{
    public class Quest
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Status { get; private set; }
        public int OriginalLocationId { get; private set; }

        internal Quest(string name, string status, int originalLocationId)
        {
            Name = name;
            Status = status;
            OriginalLocationId = originalLocationId;
        }

    }
}
