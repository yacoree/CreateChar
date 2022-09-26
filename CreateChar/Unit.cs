using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CreateChar
{
    [BsonKnownTypes(typeof(Wizard), typeof(Rogue), typeof(Warrior))]

    public class Unit
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

        /*protected string NameSet { set => name = value; }
        protected UnitProperty MaxSet { set => max = value; }
        protected int StrengthSet { set => strength = value; }
        protected int DexteritySet { set => dexterity = value; }
        protected int ConstitutionSet { set => constitution = value; }
        protected int IntelligenceSet { set => intelligence = value; }*/

        public string Name { get => name; set => name = value; }
        public UnitProperty Max { get => max; set => max = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Constitution { get => constitution; set => constitution = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }

        
        protected Unit(string name, int strength, int dexterity, int constitution, int intelligence)
        {
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Constitution = constitution;
            this.Intelligence = intelligence;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"{Name}\n\n{Max}";
        }


        /*protected Unit(int strength, int dexterity, int constitution, int intelligence)
        {
            this.StrengthSet = strength;
            this.DexteritySet = dexterity;
            this.ConstitutionSet = constitution;
            this.IntelligenceSet = intelligence;
        }*/
    }
}