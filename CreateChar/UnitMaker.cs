using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    public enum UnitsClasses
    {
        Rogue,
        Warrior,
        Wizard
    }

    public static class UnitMaker
    {
        private static readonly Dictionary<string, UnitsClasses> unitClassCode;

        public static Dictionary<string, UnitsClasses> UnitClassCode { get => unitClassCode; } 

        static UnitMaker()
        {
            unitClassCode = new Dictionary<string, UnitsClasses>()
            {
                { "Rogue",  UnitsClasses.Rogue},
                { "Warrior",  UnitsClasses.Warrior},
                { "Wizard",  UnitsClasses.Wizard},
            };
        }

        static public Unit Make(UnitsClasses pieceCode, string name, int strength, int dexterity, int constitution, int intelligence)
        {
            Unit unit = null;

            switch (pieceCode)
            {
                case UnitsClasses.Rogue:
                    unit = new Rogue(name, strength, dexterity, constitution, intelligence);
                    break;
                case UnitsClasses.Warrior:
                    unit = new Wizard(name, strength, dexterity, constitution, intelligence);
                    break;
                case UnitsClasses.Wizard:
                    unit = new Wizard(name, strength, dexterity, constitution, intelligence);
                    break;

                default:
                    throw new Exception("Unknown unit's class");
            }

            return unit;
        }

        static public Unit Make(string unitClass, string name, int strength, int dexterity, int constitution, int intelligence)
        {
            return Make(UnitClassCode[unitClass], name, strength, dexterity, constitution, intelligence);
        }

        static public Unit TransformUnit(string unitClass, Unit unit)
        {
            return Make(unitClass, unit.Name, unit.Strength, unit.Dexterity, unit.Constitution, unit.Intelligence);
        }
    }
}
