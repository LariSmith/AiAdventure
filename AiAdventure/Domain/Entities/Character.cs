namespace AiAdventure.Domain.Entities
{
    public class Character
    {
        public int Id { get; private set; }
        public int PlayerId { get; private set; }
        public string Name { get; private set; }
        public string Gender { get; private set; }
        public string Race { get; private set; }
        public string Class { get; private set; }
        public string Background { get; private set; }
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Constitution { get; private set; }
        public int Intelligence { get; private set; }
        public int Wisdom { get; private set; }
        public int Charisma { get; private set; }
        public int HitPoints { get; private set; }
        public int ArmorClass { get; private set; }
        public int Health { get; private set; }
        public int Gold { get; private set; }
        public float Experience { get; private set; }
        public float MaxExperience { get; private set; }
        public int Level { get; private set; }

        public IReadOnlyCollection<Skill> Skills => _skillList;
        public IReadOnlyCollection<Proficiency> Proficiencies => _proficienciesList;
        public IReadOnlyCollection<Feature> Features => _featureList;
        public IReadOnlyCollection<Item> Items => _itemList;

        private readonly HashSet<Skill> _skillList = new HashSet<Skill>();
        private readonly HashSet<Proficiency> _proficienciesList = new HashSet<Proficiency>();
        private readonly HashSet<Feature> _featureList = new HashSet<Feature>();
        private readonly HashSet<Item> _itemList = new HashSet<Item>();

        internal Character(int playerId, string name, string gender, string race, string @class, string background, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int hitPoints, int armorClass, int health, int gold, float experience, float maxExperience, int level)
        {
            PlayerId = playerId;
            Name = name;
            Gender = gender;
            Race = race;
            Class = @class;
            Background = background;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
            HitPoints = hitPoints;
            ArmorClass = armorClass;
            Health = health;
            Gold = gold;
            Experience = experience;
            MaxExperience = maxExperience;
            Level = level;
        }
            
        public Skill AddSkill(string description, int points)
        {
            var newsSkill = new Skill(Id, description, points);
            _skillList.Add(newsSkill);

            return newsSkill;
        }

        public Proficiency AddProficiency(string type, string? list)
        {
            var newProficiency = new Proficiency(Id, type, list);
            _proficienciesList.Add(newProficiency);

            return newProficiency;
        }

        public Feature AddFeature(string name, string description)
        {
            var newFeature = new Feature(Id, name, description);
            _featureList.Add(newFeature);

            return newFeature;
        }

        public Item AddItem(string name, int quantity)
        {
            var newItem = new Item(Id, name, quantity);
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
            UpdateMaxExperience();
        }

        public void UpdateMaxExperience()
        {
            MaxExperience += 100 * Level;
        }

        public void IncreaseGold(int value)
        {
            Gold += value;
        }

        public void DecreaseGold(int value)
        {
            var gold = Gold;

            if (gold - value < 0)
            {
                throw new ArgumentException("You don't have enough gold.");
            }

            Gold -= value;
        }

    }
}
