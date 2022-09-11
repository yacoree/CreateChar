using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    internal class Rogue : Unit
    {
        static Field strengthCharacteristic = new Field(
            minimum = 15, 
            maximum = 55,
            physicalProtection = 0,
            healthPoint = 10,
            manaPool = 0,
            physicalAttack = 20,
            magicalAttack = 0);
        static Field dexterityCharacteristic = new Field(
            minimum = 30,
            maximum = 260,
            physicalProtection = 15,
            healthPoint = 0,
            manaPool = 0,
            physicalAttack = 40,
            magicalAttack = 0);
        static Field constitutionCharacteristic = new Field(
            minimum = 20,
            maximum = 80,
            physicalProtection = 0,
            healthPoint = 60,
            manaPool = 0,
            physicalAttack = 0,
            magicalAttack = 0);
        static Field intelligenceCharacteristic = new Field(
            minimum = 15,
            maximum = 70,
            physicalProtection = 0,
            healthPoint = 0,
            manaPool = 15,
            physicalAttack = 0,
            magicalAttack = 20);


        public Rogue()
        {
            
        }
    }
}
