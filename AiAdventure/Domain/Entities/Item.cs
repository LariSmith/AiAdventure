namespace AiAdventure.Domain.Entities
{
    public class Item
    {
        public Guid Id { get; private set; }
        public Guid CharacterId { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }

        public Character Character { get; private set; }

        internal Item(Guid id, Guid characterId, string name, int quantity)
        {
            Id = id;
            CharacterId = characterId;
            Name = name;
            Quantity = quantity;
        }
    }
}
