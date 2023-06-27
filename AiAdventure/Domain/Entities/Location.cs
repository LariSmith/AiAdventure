namespace AiAdventure.Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int TurnId { get; set; }

        public Location Parent { get; set; }
        public Turn Turn { get; set; }

        public ICollection<Location> Children { get; set; }
        public ICollection<NPC> NPCs { get; set; }
        public ICollection<Quest> Quests { get; set; }
        public ICollection<Creature> Creatures { get; set; }
        public ICollection<Treasure> Treasures { get; set; }
    }
}
