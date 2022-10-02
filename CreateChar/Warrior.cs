using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    public class Warrior: Unit
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

        static Field strengthCharacteristic = new Field(30, 250, 0, 20, 0, 50, 0);
        static Field dexterityCharacteristic = new Field(15, 70, 10, 0, 0, 10, 0);
        static Field constitutionCharacteristic = new Field(20, 100, 20, 100, 0, 0, 0);
        static Field intelligenceCharacteristic = new Field(10, 50, 0, 0, 10, 0, 10);

        public static Field StrengthCharacteristic { get => strengthCharacteristic; }
        public static Field DexterityCharacteristic { get => dexterityCharacteristic; }
        public static Field ConstitutionCharacteristic { get => constitutionCharacteristic; }
        public static Field IntelligenceCharacteristic { get => intelligenceCharacteristic; }

        public override int Strength
        {
            get { return strength; }
            set
            {
                if (value >= strengthCharacteristic.Minimum)
                {
                    if (value <= strengthCharacteristic.Maximum)
                    {
                        CurrentPropertyUnit -= strengthCharacteristic.AddPoints(strength);
                        CurrentPropertyUnit += strengthCharacteristic.AddPoints(value);
                        strength = value;
                    }
                    else
                    {
                        CurrentPropertyUnit -= strengthCharacteristic.AddPoints(strength);
                        CurrentPropertyUnit += strengthCharacteristic.AddPoints(strengthCharacteristic.Maximum);
                        strength = strengthCharacteristic.Maximum;
                    }
                }
                else
                {
                    CurrentPropertyUnit -= strengthCharacteristic.AddPoints(strength);
                    CurrentPropertyUnit += strengthCharacteristic.AddPoints(strengthCharacteristic.Minimum);
                    strength = strengthCharacteristic.Minimum;
                }
            }
        }
        public override int Constitution
        {
            get { return constitution; }
            set
            {
                if (value >= constitutionCharacteristic.Minimum)
                {
                    if (value <= constitutionCharacteristic.Maximum)
                    {
                        CurrentPropertyUnit -= constitutionCharacteristic.AddPoints(constitution);
                        CurrentPropertyUnit += constitutionCharacteristic.AddPoints(value);
                        constitution = value;
                    }
                    else
                    {
                        CurrentPropertyUnit -= constitutionCharacteristic.AddPoints(constitution);
                        CurrentPropertyUnit += constitutionCharacteristic.AddPoints(constitutionCharacteristic.Maximum);
                        constitution = constitutionCharacteristic.Maximum;
                    }
                }
                else
                {
                    CurrentPropertyUnit -= constitutionCharacteristic.AddPoints(constitution);
                    CurrentPropertyUnit += constitutionCharacteristic.AddPoints(constitutionCharacteristic.Minimum);
                    constitution = constitutionCharacteristic.Minimum;
                }
            }
        }
        public override int Dexterity
        {
            get { return dexterity; }
            set
            {
                if (value >= dexterityCharacteristic.Minimum)
                {
                    if (value <= dexterityCharacteristic.Maximum)
                    {
                        CurrentPropertyUnit -= dexterityCharacteristic.AddPoints(dexterity);
                        CurrentPropertyUnit += dexterityCharacteristic.AddPoints(value);
                        dexterity = value;
                    }
                    else
                    {
                        CurrentPropertyUnit -= dexterityCharacteristic.AddPoints(dexterity);
                        CurrentPropertyUnit += dexterityCharacteristic.AddPoints(dexterityCharacteristic.Maximum);
                        dexterity = dexterityCharacteristic.Maximum;
                    }
                }
                else
                {
                    CurrentPropertyUnit -= dexterityCharacteristic.AddPoints(dexterity);
                    CurrentPropertyUnit += dexterityCharacteristic.AddPoints(dexterityCharacteristic.Minimum);
                    dexterity = dexterityCharacteristic.Minimum;
                }
            }
        }
        public override int Intelligence
        {
            get { return intelligence; }
            set
            {
                if (value >= intelligenceCharacteristic.Minimum)
                {
                    if (value <= intelligenceCharacteristic.Maximum)
                    {
                        CurrentPropertyUnit -= intelligenceCharacteristic.AddPoints(intelligence);
                        CurrentPropertyUnit += intelligenceCharacteristic.AddPoints(value);
                        intelligence = value;
                    }
                    else
                    {
                        CurrentPropertyUnit -= intelligenceCharacteristic.AddPoints(intelligence);
                        CurrentPropertyUnit += intelligenceCharacteristic.AddPoints(intelligenceCharacteristic.Maximum);
                        intelligence = intelligenceCharacteristic.Maximum;
                    }
                }
                else
                {
                    CurrentPropertyUnit -= intelligenceCharacteristic.AddPoints(intelligence);
                    CurrentPropertyUnit += intelligenceCharacteristic.AddPoints(intelligenceCharacteristic.Minimum);
                    intelligence = intelligenceCharacteristic.Minimum;
                }
            }
        }

        public Warrior(string name, int strength, int dexterity, int constitution, int intelligence) : 
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

    }
}
