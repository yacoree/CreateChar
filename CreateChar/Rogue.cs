using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
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

        public static Field strengthCharacteristic = new Field(15, 55, 0, 10, 0, 20, 0);
        public static Field dexterityCharacteristic = new Field(30, 260, 15, 0, 0, 40, 0);
        public static Field constitutionCharacteristic = new Field(20, 80, 0, 60, 0, 0, 0);
        public static Field intelligenceCharacteristic = new Field(15, 70, 0, 0, 15, 0, 20);


        public Rogue(int strength, int dexterity, int constitution, int intelligence) : base(strength, dexterity, constitution, intelligence)
        {
            max = strengthCharacteristic.AddPoint(strength) + dexterityCharacteristic.AddPoint(dexterity) 
                + constitutionCharacteristic.AddPoint(constitution) + intelligenceCharacteristic.AddPoint(intelligence);
        }
    }
}
