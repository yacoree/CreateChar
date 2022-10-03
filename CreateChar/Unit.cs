using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CreateChar
{
    public struct CountOfItem
    {
        public CountOfItem(Item item, int count)
        {
            Item = item;
            Count = count;
        }
        public Item Item { get; set; }
        public int Count { get; set; }
    }

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
        List<Skill> unitSkills;

       [BsonIgnoreIfNull]
        public List<CountOfItem> Inventory { get; set; }
        public List<Item> WornItems { get; set; }
        public List<Skill> UnitSkills
        {
            get { return unitSkills; }
            set
            {
                foreach(Skill skill in unitSkills)
                {
                    if (skill.SkillProperty != null) CurrentPropertyUnit -= skill.SkillProperty;
                    if (skill.Strength != 0) Strength -= skill.Strength;
                    if (skill.Dexterity != 0) Dexterity  -= skill.Dexterity;
                    if (skill.Constitution != 0) Constitution -= skill.Constitution;
                    if (skill.Intelligence != 0) Intelligence -= skill.Intelligence;
                    if (skill.LoadCapacity != 0) LoadCapacity -= skill.LoadCapacity;
                    if (skill.SkillPoints != 0) SkillPoints -= skill.SkillPoints;
                }
                unitSkills = value;
                foreach (Skill skill in unitSkills)
                {
                    if (skill.SkillProperty != null) CurrentPropertyUnit += skill.SkillProperty;
                    if (skill.Strength != 0) Strength += skill.Strength;
                    if (skill.Dexterity != 0) Dexterity += skill.Dexterity;
                    if (skill.Constitution != 0) Constitution += skill.Constitution;
                    if (skill.Intelligence != 0) Intelligence += skill.Intelligence;
                    if (skill.LoadCapacity != 0) LoadCapacity += skill.LoadCapacity;
                    if (skill.SkillPoints != 0) SkillPoints += skill.SkillPoints;
                }
            }
        }
        public UnitProperty CurrentPropertyUnit { get; set; }
        public string Name { get; set; }
        public virtual int Strength 
        { 
            get { return strength; } 
            set
            {
                strength = value;
                LoadCapacity = strength * 200;
            }
        }
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
            Name = name;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            PointsToNextLevel = scalePointsForNextLevel;
            CurrentExperience = 0;
            Level = 1;
            SkillPoints = standartSkilloints;
            Inventory = new List<CountOfItem>();
            WornItems = new List<Item>();
            UnitSkills = new List<Skill>();
        }

        public int setField(int num)
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

        public bool AddItemToInventory(Item item)
        {
            var inventoryWeight = 0;
            foreach (var i in Inventory) inventoryWeight += i.Item.ItemWeight * i.Count;
            if (LoadCapacity < inventoryWeight + item.ItemWeight) return false;
            for (var i = 0; i < Inventory.Count; i++)
            {
                if (Inventory[i].Item.ItemName == item.ItemName)
                {
                    if (Inventory[i].Item.EqualItem(item))
                    {
                        Inventory[i] = new CountOfItem(Inventory[i].Item, Inventory[i].Count + 1);
                    }
                    return Inventory[i].Item.EqualItem(item);
                }
            }
            Inventory.Add(new CountOfItem(item, 1));
            return true;
        }

        public bool LayOutItemFromInventory(Item item)
        {
            for (var i = 0; i < Inventory.Count; i++)
            {
                if (Inventory[i].Item.ItemName == item.ItemName)
                {
                    var numberOfItemsWorn = 0;
                    for (var j = 0; j < WornItems.Count; j++)
                    {
                        if (Inventory[i].Item.EqualItem(WornItems[j]))
                        {
                            numberOfItemsWorn++;
                        }
                    }
                    if (numberOfItemsWorn == Inventory[i].Count) RemoveItem(item);
                    if (Inventory[i].Count > 1) Inventory[i] = new CountOfItem(Inventory[i].Item, Inventory[i].Count - 1); 
                    else Inventory.RemoveAt(i);
                    return true;
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
                    if (i.Item.EqualItem(item))
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