using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    internal class Wisard
    {
        static Field strengthCharacteristic = new Field(
            minimum = 10,
            maximum = 45,
            physicalProtection = 0,
            healthPoint = 10,
            manaPool = 0,
            physicalAttack = 30,
            magicalAttack = 0);
        static Field dexterityCharacteristic = new Field(
            minimum = 20,
            maximum = 70,
            physicalProtection = 5,
            healthPoint = 0,
            manaPool = 0,
            physicalAttack = 0,
            magicalAttack = 0);
        static Field constitutionCharacteristic = new Field(
            minimum = 15,
            maximum = 60,
            physicalProtection = 10,
            healthPoint = 30,
            manaPool = 0,
            physicalAttack = 0,
            magicalAttack = 0);
        static Field intelligenceCharacteristic = new Field(
            minimum = 35,
            maximum = 250,
            physicalProtection = 0,
            healthPoint = 0,
            manaPool = 20,
            physicalAttack = 0,
            magicalAttack = 50);


    }
}
