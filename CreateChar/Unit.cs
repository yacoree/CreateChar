namespace CreateChar
{
    abstract class Unit
    {
        static Field strengthCharacteristic;
        static Field dexterityCharacteristic;
        static Field constitutionCharacteristic;
        static Field intelligenceCharacteristic;

        int strength;
        int dexterity;
        int constitution;
        int intelligence;

        UnitProperty max;
        UnitProperty current;

        public Unit()
        {

        }

        protected Unit(int strength, int dexterity, int constitution, int intelligence)
        {
            this.strength = strength;
            this.dexterity = dexterity;
            this.constitution = constitution;
            this.intelligence = intelligence;
        }
    }
}