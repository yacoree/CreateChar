using CreateChar.PartsOfUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar.Items
{
    public class Helmet : Item
    {
        public Helmet(string itemName) : base(itemName)
        {
        }

        public Helmet(string itemName, int itemWeight) : base(itemName, itemWeight)
        {
        }

        public Helmet(string itemName, int itemWeight, UnitProperty itemPropery) : base(itemName, itemWeight, itemPropery)
        {
        }
    }
}
