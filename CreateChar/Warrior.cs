using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    internal class Warrior: Unit
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

        public Warrior(int strength, int dexterity, int constitution, int intelligence) : base(strength, dexterity, constitution, intelligence)
        {
            max = strengthCharacteristic.AddPoint(strength) + dexterityCharacteristic.AddPoint(dexterity)
                + constitutionCharacteristic.AddPoint(constitution) + intelligenceCharacteristic.AddPoint(intelligence);
        }

    }
}
