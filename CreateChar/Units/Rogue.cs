using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateChar.PartsOfUnits;

namespace CreateChar.Units
{
    public class Rogue : Unit
    {
        /*
            Порядок записи 
            minimum = 10,
            maximum = 45,
            physicalProtection = 0,
            healthPoint = 10,
            manaPool = 0,
            physicalAttack = 30,
            magicalAttack = 0
        */
        //private static Field Field = new Field { Minimum = 10, Maximum = 20, Property = new UnitProperty { } }
        private static Field strengthCharacteristic = new Field(15, 55, 0, 10, 0, 20, 0);
        private static Field dexterityCharacteristic = new Field(30, 260, 15, 0, 0, 40, 0);
        private static Field constitutionCharacteristic = new Field(20, 80, 0, 60, 0, 0, 0);
        private static Field intelligenceCharacteristic = new Field(15, 70, 0, 0, 15, 0, 20);

        public static Field StrengthCharacteristic { get => strengthCharacteristic; }
        public static Field DexterityCharacteristic { get => dexterityCharacteristic; }
        public static Field ConstitutionCharacteristic { get => constitutionCharacteristic; }
        public static Field IntelligenceCharacteristic { get => intelligenceCharacteristic; }


        public Rogue(string name, int strength, int dexterity, int constitution, int intelligence) :
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
            int predval = SkillPoints - value >= 0 ? value : SkillPoints;
            int newValue;
            switch (field)
            {
                case "Strength":
                    newValue = StrengthCharacteristic.SetFieldValue(Strength + predval);
                    CurrentPropertyUnit += StrengthCharacteristic.SetUnitPropertydValue(Strength, predval + Strength);
                    SkillPoints += Strength - newValue;
                    Strength = newValue;
                    LoadCapacity = Strength * 500;
                    break;
                case "Constitution":
                    newValue = constitutionCharacteristic.SetFieldValue(Constitution + predval);
                    CurrentPropertyUnit += constitutionCharacteristic.SetUnitPropertydValue(Constitution, predval + Constitution);
                    SkillPoints += Constitution - newValue;
                    Constitution = newValue;
                    break;
                case "Dexterity":
                    newValue = dexterityCharacteristic.SetFieldValue(Dexterity + predval);
                    CurrentPropertyUnit += dexterityCharacteristic.SetUnitPropertydValue(Dexterity, predval + Dexterity);
                    SkillPoints += Dexterity - newValue;
                    Dexterity = newValue;
                    break;
                case "Intelligence":
                    newValue = intelligenceCharacteristic.SetFieldValue(Intelligence + predval);
                    CurrentPropertyUnit += intelligenceCharacteristic.SetUnitPropertydValue(Intelligence, predval + Intelligence);
                    SkillPoints += Intelligence - newValue;
                    Intelligence = newValue;
                    break;
            }
        }
    }
}
