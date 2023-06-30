namespace AiAdventure.Domain.Entities
{
    public class Location
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int? ParentId { get; private set; }
        public int TurnId { get; private set; }

        public Location? Parent { get; private set; }

        public IReadOnlyCollection<NPC> NPCs => _npcs;
        public IReadOnlyCollection<Quest> Quests => _quests;
        public IReadOnlyCollection<Creature> Creatures => _creatures;
        public IReadOnlyCollection<Treasure> Treasures => _treasures;

        private readonly HashSet<NPC> _npcs = new HashSet<NPC>();
        private readonly HashSet<Quest> _quests = new HashSet<Quest>();
        private readonly HashSet<Creature> _creatures = new HashSet<Creature>();
        private readonly HashSet<Treasure> _treasures = new HashSet<Treasure>();

        internal Location(string name, int turnId, int? parentId)
        {
            Name = name;
            ParentId = parentId;
            TurnId = turnId;
        }

        public NPC AddNpc(string name, string race, bool isPartyMember, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int hitPoints, int armorClass, int health, float experience, int level)
        {
            var npc = new NPC(
                                name,
                                race,
                                isPartyMember,
                                strength,
                                dexterity,
                                constitution,
                                intelligence,
                                wisdom,
                                charisma,
                                hitPoints,
                                armorClass,
                                health,
                                experience,
                                level,
                                Id);

            _npcs.Add(npc);
            return npc;
        }

        public Quest AddQuest(string name, string status)
        {
            var quest = new Quest(name, status, Id);
            _quests.Add(quest);
            return quest;
        }

        public Creature AddCreature(string name, string race, int strength, int dexterity, int constitution, int intelligence, int wisdom, int hitpoints, int armorclass, int health, int level)
        {
            var creature = new Creature(Id, name, race, strength, dexterity, constitution, intelligence, wisdom, hitpoints, armorclass, health, level);
            _creatures.Add(creature);
            return creature;
        }
        
        public Treasure AddTreasure(string name, string description)
        {
            var treasure = new Treasure(name, description, Id);
            _treasures.Add(treasure);
            return treasure;
        }

    }
}
