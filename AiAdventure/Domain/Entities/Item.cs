namespace AiAdventure.Domain.Entities
{
    public class Item
    {
        public int Id { get; private set; }
        public int CharacterId { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }

        internal Item(int characterId, string name, int quantity)
        {
            CharacterId = characterId;
            Name = name;
            Quantity = quantity;
        }
    }
}
