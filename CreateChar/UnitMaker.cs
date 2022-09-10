using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    internal class UnitMaker
    {
        static Dictionary<string, int> Warrior = new Dictionary<string, int>()
        {
            {"MinStrength", 30},
            {"MinDexterity", 15},
            {"MinConstitution", 20},
            {"MinIntelligence", 10},

            {"MaxStrength", 250},
            {"MaxDexterity", 20},
            {"MaxConstitution", 100},
            {"MaxIntelligence", 50}
        };

        static Dictionary<string, int> Rogues = new Dictionary<string, int>()
        {
            {"MinStrength", 15},
            {"MinDexterity", 30},
            {"MinConstitution", 20},
            {"MinIntelligence", 15},

            {"MaxStrength", 55},
            {"MaxDexterity", 260},
            {"MaxConstitution", 80},
            {"MaxIntelligence", 70}
        };

        static Dictionary<string, int> Wisard = new Dictionary<string, int>()
        {
            {"MinStrength", 10},
            {"MinDexterity", 20},
            {"MinConstitution", 15},
            {"MinIntelligence", 35},

            {"MaxStrength", 45},
            {"MaxDexterity", 70},
            {"MaxConstitution", 60},
            {"MaxIntelligence", 250}
        };
    }
}
