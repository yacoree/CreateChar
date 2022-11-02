using CreateChar.PartsOfUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar.Items
{
    public class Weapon : Item
    {
        public Weapon(string itemName) : base(itemName)
        {
        }

        public Weapon(string itemName, int itemWeight) : base(itemName, itemWeight)
        {
        }

        public Weapon(string itemName, int itemWeight, UnitProperty itemPropery) : base(itemName, itemWeight, itemPropery)
        {
        }
    }
}
