﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    public class Wizard : Unit
    {
        /*
         * Порядок записи 
            minimum = 10,
            maximum = 45,
            physicalProtection = 0,
            healthPoint = 10,
            manaPool = 0,
            physicalAttack = 30,
            magicalAttack = 0
        */

        static Field strengthCharacteristic = new Field(10, 45, 0, 10, 0, 30, 0);
        static Field dexterityCharacteristic = new Field(20, 70, 5, 0, 0, 0, 0);
        static Field constitutionCharacteristic = new Field(15, 60, 10, 30, 0, 0, 0);
        static Field intelligenceCharacteristic = new Field(35, 250, 0, 0, 20, 0, 50);

        public static Field StrengthCharacteristic { get => strengthCharacteristic; }
        public static Field DexterityCharacteristic { get => dexterityCharacteristic; }
        public static Field ConstitutionCharacteristic { get => constitutionCharacteristic; }
        public static Field IntelligenceCharacteristic { get => intelligenceCharacteristic; }

        public Wizard(string name, int strength, int dexterity, int constitution, int intelligence) :
            base(name, strength, dexterity, constitution, intelligence)
        {
            CurrentPropertyUnit += TakeUnitStats(strength, dexterity, constitution, intelligence);
        }

        public static UnitProperty TakeUnitStats(int strength, int dexterity, int constitution, int intelligence)
        {
            var res = strengthCharacteristic.SetPoints(strength) 
                + dexterityCharacteristic.SetPoints(dexterity)
                + constitutionCharacteristic.SetPoints(constitution) 
                + intelligenceCharacteristic.SetPoints(intelligence);
            return res;
        }

        public override void SetField(string field, int value)
        {
            int predval;
            int newValue;
            switch (field)
            {
                case "Strength":
                    predval = SkillPoints + strength - value >= 0 ? value : SkillPoints;
                    newValue = StrengthCharacteristic.SetFieldValue(predval);
                    CurrentPropertyUnit += StrengthCharacteristic.SetUnitPropertydValue(strength, predval);
                    SkillPoints += strength - newValue;
                    strength = newValue;
                    LoadCapacity = strength * 500;
                    break;
                case "Constitution":
                    predval = SkillPoints + constitution - value >= 0 ? value : SkillPoints;
                    newValue = constitutionCharacteristic.SetFieldValue(predval);
                    CurrentPropertyUnit += constitutionCharacteristic.SetUnitPropertydValue(constitution, predval);
                    SkillPoints += constitution - newValue;
                    constitution = newValue;
                    break;
                case "Dexterity":
                    predval = SkillPoints + dexterity - value >= 0 ? value : SkillPoints;
                    newValue = dexterityCharacteristic.SetFieldValue(predval);
                    CurrentPropertyUnit += dexterityCharacteristic.SetUnitPropertydValue(dexterity, predval);
                    SkillPoints += dexterity - newValue;
                    dexterity = newValue;
                    break;
                case "Intelligence":
                    predval = SkillPoints + intelligence - value >= 0 ? value : SkillPoints;
                    newValue = intelligenceCharacteristic.SetFieldValue(predval);
                    CurrentPropertyUnit += intelligenceCharacteristic.SetUnitPropertydValue(intelligence, predval);
                    SkillPoints += intelligence - newValue;
                    intelligence = newValue;
                    break;
            }
        }
    }
}