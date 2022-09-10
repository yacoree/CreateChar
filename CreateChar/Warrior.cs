using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    internal class Warrior: Unit
    {
        static int[] strengthUp = new int[] { 5, 2 };
        static int[] dexterityUp = new int[] { 1, 1 };
        static int[] constitutionUp = new int[] { 10, 2 };
        static int[] intelligenceUp = new int[] { 1, 1 };

        int MinStrength = 30;
        int MinDexterity = 15;
        int MinConstitution = 20;
        int MinIntelligence = 10;

        int MaxStrength = 250;
        int MaxDexterity = 20;
        int MaxConstitution = 100;
        int MaxIntelligence = 50;
    }
}
