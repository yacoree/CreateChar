using CreateChar.Items;
using CreateChar.PartsOfUnits;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.Collections.Generic;

namespace CreateChar.Units
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

        [BsonIgnoreIfNull]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<Item, int> Inventory { get; set; }
        [BsonIgnoreIfNull]
        public List<Item> WornItems { get; set; }
        [BsonIgnoreIfNull]
        public List<Skill> UnitSkills { get; set; }
        public UnitProperty CurrentPropertyUnit { get; set; }
        public string Name { get; set; }
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
            Name = name;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            PointsToNextLevel = scalePointsForNextLevel;
            CurrentExperience = 0;
            Level = 1;
            LoadCapacity = 500 * Strength;
            SkillPoints = standartSkilloints;
            Inventory = new Dictionary<Item, int>();
            WornItems = new List<Item>();
            UnitSkills = new List<Skill>();
        }

        public abstract void SetField(string field, int num);

        public override string ToString()
        {
            return $"{Name}\n {GetType().Name} {Level}lvl. \n{CurrentPropertyUnit}";
        }

        public bool AddItemToInventory(Item item)
        {
            var inventoryWeight = 0;
            foreach (var i in Inventory) inventoryWeight += i.Key.ItemWeight * i.Value;
            if (LoadCapacity < inventoryWeight + item.ItemWeight) return false;
            foreach (var i in Inventory)
            {
                if (i.Key.ItemName == item.ItemName)
                {
                    if (i.Key.EqualItem(item))
                    {
                        Inventory[i.Key]++;
                    }
                    return i.Key.EqualItem(item);
                }
            }
            Inventory.Add(item, 1);
            return true;
        }

        public bool LayOutItemFromInventory(Item item)
        {
            foreach (var i in Inventory)
            {
                if (i.Key.ItemName == item.ItemName)
                {
                    var numberOfItemsWorn = 0;
                    foreach (var j in WornItems)
                    {
                        if (i.Key.EqualItem(j))
                        {
                            numberOfItemsWorn++;
                        }
                    }
                    if (numberOfItemsWorn == i.Value) RemoveItem(item);
                    if (i.Value > 1) Inventory[i.Key]--;
                    else Inventory.Remove(i.Key);
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
                    if (i.Key.EqualItem(item))
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

        public void AddSkill(Skill newSkill)
        {
            foreach (Skill skill in UnitSkills)
            {
                if (skill.SkillProperty != null) CurrentPropertyUnit -= skill.SkillProperty;
                if (skill.Strength != 0) Strength -= skill.Strength;
                if (skill.Dexterity != 0) Dexterity -= skill.Dexterity;
                if (skill.Constitution != 0) Constitution -= skill.Constitution;
                if (skill.Intelligence != 0) Intelligence -= skill.Intelligence;
                if (skill.LoadCapacity != 0) LoadCapacity -= skill.LoadCapacity;
                if (skill.SkillPoints != 0) SkillPoints -= skill.SkillPoints;
            }
            UnitSkills.Add(newSkill);
            foreach (Skill skill in UnitSkills)
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
}