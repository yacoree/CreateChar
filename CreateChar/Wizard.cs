using System;
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
            get { return strength; }
            set
            {
                if (value >= constitutionCharacteristic.Minimum)
                {
                    if (value <= constitutionCharacteristic.Maximum)
                    {
                        CurrentPropertyUnit -= constitutionCharacteristic.AddPoints(strength);
                        CurrentPropertyUnit += constitutionCharacteristic.AddPoints(value);
                        strength = value;
                    }
                    else
                    {
                        CurrentPropertyUnit -= constitutionCharacteristic.AddPoints(strength);
                        CurrentPropertyUnit += constitutionCharacteristic.AddPoints(constitutionCharacteristic.Maximum);
                        strength = constitutionCharacteristic.Maximum;
                    }
                }
                else
                {
                    CurrentPropertyUnit -= constitutionCharacteristic.AddPoints(strength);
                    CurrentPropertyUnit += constitutionCharacteristic.AddPoints(constitutionCharacteristic.Minimum);
                    strength = constitutionCharacteristic.Minimum;
                }
            }
        }
        public override int Dexterity
        {
            get { return strength; }
            set
            {
                if (value >= dexterityCharacteristic.Minimum)
                {
                    if (value <= dexterityCharacteristic.Maximum)
                    {
                        CurrentPropertyUnit -= dexterityCharacteristic.AddPoints(strength);
                        CurrentPropertyUnit += dexterityCharacteristic.AddPoints(value);
                        strength = value;
                    }
                    else
                    {
                        CurrentPropertyUnit -= dexterityCharacteristic.AddPoints(strength);
                        CurrentPropertyUnit += dexterityCharacteristic.AddPoints(dexterityCharacteristic.Maximum);
                        strength = dexterityCharacteristic.Maximum;
                    }
                }
                else
                {
                    CurrentPropertyUnit -= dexterityCharacteristic.AddPoints(strength);
                    CurrentPropertyUnit += dexterityCharacteristic.AddPoints(dexterityCharacteristic.Minimum);
                    strength = dexterityCharacteristic.Minimum;
                }
            }
        }
        public override int Intelligence
        {
            get { return strength; }
            set
            {
                if (value >= intelligenceCharacteristic.Minimum)
                {
                    if (value <= intelligenceCharacteristic.Maximum)
                    {
                        CurrentPropertyUnit -= intelligenceCharacteristic.AddPoints(strength);
                        CurrentPropertyUnit += intelligenceCharacteristic.AddPoints(value);
                        strength = value;
                    }
                    else
                    {
                        CurrentPropertyUnit -= intelligenceCharacteristic.AddPoints(strength);
                        CurrentPropertyUnit += intelligenceCharacteristic.AddPoints(intelligenceCharacteristic.Maximum);
                        strength = intelligenceCharacteristic.Maximum;
                    }
                }
                else
                {
                    CurrentPropertyUnit -= intelligenceCharacteristic.AddPoints(strength);
                    CurrentPropertyUnit += intelligenceCharacteristic.AddPoints(intelligenceCharacteristic.Minimum);
                    strength = intelligenceCharacteristic.Minimum;
                }
            }
        }

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

    }
}
