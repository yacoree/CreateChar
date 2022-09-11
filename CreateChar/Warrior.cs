using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    internal class Warrior: Unit
    {
        static Field strengthCharacteristic = new Field(
            minimum = 30,
            maximum = 250,
            physicalProtection = 0,
            healthPoint = 20,
            manaPool = 0,
            physicalAttack = 50,
            magicalAttack = 0);
        static Field dexterityCharacteristic = new Field(
            minimum = 15,
            maximum = 70,
            physicalProtection = 10,
            healthPoint = 0,
            manaPool = 0,
            physicalAttack = 10,
            magicalAttack = 0);
        static Field constitutionCharacteristic = new Field(
            minimum = 20,
            maximum = 100,
            physicalProtection = 20,
            healthPoint = 100,
            manaPool = 0,
            physicalAttack = 0,
            magicalAttack = 0);
        static Field intelligenceCharacteristic = new Field(
            minimum = 10,
            maximum = 50,
            physicalProtection = 0,
            healthPoint = 0,
            manaPool = 10,
            physicalAttack = 0,
            magicalAttack = 10);

    }
}
