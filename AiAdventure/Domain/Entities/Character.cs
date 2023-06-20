namespace AiAdventure.Domain.Entities
{
    public class Character
    {
        public Guid Id { get; private set; }
        public Guid TurnId { get; private set; }
        public string Name { get; private set; }
        public char Gender { get; private set; }
        public string Class { get; private set; }
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Constitution { get; private set; }
        public int Intelligence { get; private set; }
        public int Wisdom { get; private set; }
        public int Charisma { get; private set; }
        public int HitPoints { get; private set; }
        public int ArmorClass { get; private set; }
        public int Health { get; private set; }
        public float Experience { get; private set; }
        public float MaxExperience { get; private set; }
        public int Level { get; private set; }

        public IReadOnlyCollection<Skill> Skills => _skillList;
        public IReadOnlyCollection<Proficiency> Proficiencies => _proficienciesList;
        public IReadOnlyCollection<Feature> Features => _featureList;
        public IReadOnlyCollection<Item> Inventory => _itemList;

        private HashSet<Skill> _skillList = new HashSet<Skill>();
        private HashSet<Proficiency> _proficienciesList = new HashSet<Proficiency>();
        private HashSet<Feature> _featureList = new HashSet<Feature>();
        private HashSet<Item> _itemList = new HashSet<Item>();

        private Character(Guid id, Guid turnId, string name, char gender, string @class, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int hitPoints, int armorClass, int health, float experience, float maxExperience, int level)
        {
            Id = id;
            TurnId = turnId;
            Name = name;
            Gender = gender;
            Class = @class;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
            HitPoints = hitPoints;
            ArmorClass = armorClass;
            Health = health;
            Experience = experience;
            MaxExperience = maxExperience;
            Level = level;
        }
        
        public virtual Character Create(Guid id, Guid turnId, string name, char gender, string @class, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int hitPoints, int armorClass, int health, float experience, float maxExperience, int level)
        {
            return new Character(id, turnId, name, gender, @class, strength, dexterity, constitution, intelligence, wisdom, charisma, hitPoints, armorClass, health, experience, maxExperience, level);
        }
    
        public Skill AddSkill(string description, int points)
        {
            var newsSkill = new Skill(Guid.NewGuid(), Id, description, points);
            _skillList.Add(newsSkill);

            return newsSkill;
        }

        public Proficiency AddProficiency(string type, string list)
        {
            var newProficiency = new Proficiency(Guid.NewGuid(), Id, type, list);
            _proficienciesList.Add(newProficiency);

            return newProficiency;
        }

        public Feature AddFeature(string name, string description)
        {
            var newFeature = new Feature(Guid.NewGuid(), Id, name, description);
            _featureList.Add(newFeature);

            return newFeature;
        }

        public Item AddItem(string name, int quantity)
        {
            var newItem = new Item(Guid.NewGuid(), Id, name, quantity);
            _itemList.Add(newItem);

            return newItem;
        }

        public void UpdateStatus(int strength, int dexteriry, int constitution, int intelligence, int wisdom, int charisma, int hitPoints, int armorClass, int health)
        {
            Strength = strength;
            Dexterity = dexteriry;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
            HitPoints = hitPoints;
            ArmorClass = armorClass;
            Health = health;
        }

        public void IncreaseExperience(float value)
        {
            Experience += value;

            if (Experience >= MaxExperience)
                LevelUp(Experience - MaxExperience);
        }

        public void LevelUp(float value)
        {
            Level++;
            IncreaseExperience(value);
        }
    }
}
