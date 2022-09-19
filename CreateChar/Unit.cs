using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CreateChar
{
    public abstract class Unit
    {
        protected int strength;
        protected int dexterity;
        protected int constitution;
        protected int intelligence;

        protected string name;

        protected UnitProperty max;
        protected UnitProperty current;

        [BsonId]
        ObjectId id;

        public string Name { get => name; }
        public UnitProperty Max { get => max; }
        public UnitProperty Current { get => current; }

        protected Unit(int strength, int dexterity, int constitution, int intelligence)
        {
            this.strength = strength;
            this.dexterity = dexterity;
            this.constitution = constitution;
            this.intelligence = intelligence;
        }
        protected Unit(string name, int strength, int dexterity, int constitution, int intelligence)
        {
            this.strength = strength;
            this.dexterity = dexterity;
            this.constitution = constitution;
            this.intelligence = intelligence;
            this.name = name;
        }
    }
}