namespace AiAdventure.Domain.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public Guid CharacterId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Character Character { get; set; }
    }
}
