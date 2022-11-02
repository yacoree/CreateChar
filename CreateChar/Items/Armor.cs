using CreateChar.PartsOfUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar.Items
{
    public class Armor : Item
    {
        public Armor(string itemName) : base(itemName)
        {
        }

        public Armor(string itemName, int itemWeight) : base(itemName, itemWeight)
        {
        }

        public Armor(string itemName, int itemWeight, UnitProperty itemPropery) : base(itemName, itemWeight, itemPropery)
        {
        }
    }
}
