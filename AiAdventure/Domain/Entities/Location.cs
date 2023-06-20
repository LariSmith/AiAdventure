namespace AiAdventure.Domain.Entities
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public Guid TurnId { get; set; }

        public Location Parent { get; set; }
        public Turn Turn { get; set; }

        public ICollection<Location> Children { get; set; }
        public ICollection<NPC> NPCs { get; set; }
        public ICollection<Quest> Quests { get; set; }
        public ICollection<Creature> Creatures { get; set; }
        public ICollection<Treasure> Treasures { get; set; }
    }
}
