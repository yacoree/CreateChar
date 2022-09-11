﻿namespace CreateChar
{
    abstract class Unit
    {
        static Field strengthCharacteristic;
        static Field dexterityCharacteristic;
        static Field constitutionCharacteristic;
        static Field intelligenceCharacteristic;

        protected int strength;
        protected int dexterity;
        protected int constitution;
        protected int intelligence;

        protected UnitProperty max;
        protected UnitProperty current;

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