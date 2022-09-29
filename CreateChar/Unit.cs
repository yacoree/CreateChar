﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CreateChar
{
    [BsonKnownTypes(typeof(Wizard), typeof(Rogue), typeof(Warrior))]
    public abstract class Unit
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId id;

        private string name;
        private UnitProperty max;
        private int strength;
        private int dexterity;
        private int constitution;
        private int intelligence;

        [BsonIgnoreIfNull]
        public List<Item> Items { get; set; }
        public string Name { get => name; set => name = value; }
        public UnitProperty Max { get => max; set => max = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Constitution { get => constitution; set => constitution = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Experience { get; set; }

        protected Unit(string name, int strength, int dexterity, int constitution, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Name = name;
            Items = new List<Item>();
        }

        public override string ToString()
        {
            return $"{Name}\n\n{Max}";
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void Removeitem(Item item)
        {
            Items.Remove(item);
        }
    }
}