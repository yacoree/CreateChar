using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using static System.Net.Mime.MediaTypeNames;

namespace CreateChar
{
    [BsonKnownTypes(typeof(Wizard), typeof(Rogue), typeof(Warrior))]
    public abstract class Unit
    {
        static int maxLevel = 10;
        static int scalePointsForNextLevel = 1000;
        static int standartSkilloints = 50;
        static int increasingPoints = 5;

        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId id;

        int currentExperience;
        protected int strength;
        protected int dexterity;
        protected int constitution;
        protected int intelligence;

        [BsonIgnoreIfNull]
        public Dictionary<Item, int> Inventory { get; set; }
        public List<Item> WornItems { get; set; }
        public List<Skill> UnitSkills { get; set; }
        public string Name { get; set; }
        public UnitProperty CurrentPropertyUnit { get; set; }
        public virtual int Strength { get; set; }
        public virtual int Dexterity { get; set; }
        public virtual int Constitution { get; set; }
        public virtual int Intelligence { get; set; }
        public int LoadCapacity { get; set; }
        public int SkillPoints { get; set; }
        public int Level { get; set; }
        public int PointsToNextLevel { get; set; }
        public int CurrentExperience
        {
            get { return currentExperience; }
            set
            {
                currentExperience = value;
                if (currentExperience >= PointsToNextLevel)
                {
                    Level++;
                    PointsToNextLevel += Level * scalePointsForNextLevel;
                    SkillPoints += IncreasingPoints;
                    if (Level % 5 == 0)
                    { }
                }
            }
        }

        public static int IncreasingPoints { get => increasingPoints; }

        protected Unit(string name, int strength, int dexterity, int constitution, int intelligence)
        {
            CurrentPropertyUnit = new UnitProperty();
            PointsToNextLevel = scalePointsForNextLevel;
            CurrentExperience = 0;
            Level = 1;
            SkillPoints = standartSkilloints;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            LoadCapacity = Strength * 200;
            Name = name;
            Inventory = new Dictionary<Item, int>();
            
        }

        private int setField(int num)
        {
            int res;
            if (SkillPoints - num >= 0)
            {
                SkillPoints -= num;
                return num;
            }
            res = SkillPoints;
            SkillPoints = 0;
            return res;
        }

        public override string ToString()
        {
            return $"{Name}\n {this.GetType().Name} {Level}lvl. \n{CurrentPropertyUnit}";
        }

        public void AddItemToInventory(Item item)
        {
            var inventoryWeight = 0;
            foreach (var i in Inventory) inventoryWeight += i.Key.ItemWeight * i.Value;
            if (LoadCapacity >= inventoryWeight + item.ItemWeight)
            {
                foreach (var i in Inventory)
                {
                    if (i.Key == item)
                    {
                        Inventory[i.Key]++;
                        return;
                    }
                }
                Inventory.Add(item, 1);
            }
        }

        public bool LayOutItemFromInventory(Item item)
        {
            foreach (var i in Inventory)
            {
                if (i.Key == item)
                {
                    if (i.Value > 1)
                    {
                        Inventory[i.Key]--;
                        return true;
                    }
                    else
                    {
                        Inventory.Remove(item);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PutOnItem(Item item)
        {
            if (item.ItemPropery != null)
            {
                foreach (var i in Inventory)
                {
                    if (i.Key == item)
                    {
                        WornItems.Add(item);
                        CurrentPropertyUnit += item.ItemPropery;
                        return true;
                    }
                }
            }
            return false;
        }

        public void RemoveItem(Item item)
        {
            if (WornItems.Remove(item)) CurrentPropertyUnit -= item.ItemPropery;
        }
    }
}