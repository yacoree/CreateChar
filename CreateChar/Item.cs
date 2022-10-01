using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    public class Item
    {
        public string ItemName { get; set; }
        public int ItemWeight { get; set; }
        public UnitProperty ItemPropery { get; set; }

        public Item(string itemName) : this(itemName, 0)
        {
            ItemName = itemName;
        }

        public Item(string itemName, int itemWeight)
        {
            ItemName = itemName;
            ItemWeight = itemWeight;
        }

        public Item(string itemName, int itemWeight, UnitProperty itemPropery) : this(itemName, itemWeight)
        {
            ItemPropery = itemPropery;
        }

        //Понимаю, что это не правильно, но пока не знаю как правильно переопределять GetHashCode
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType().Name != this.GetType().Name) return false;
            if ((obj as Item).ItemName != this.ItemName) return false;
            if ((obj as Item).ItemWeight != this.ItemWeight) return false;
            if ($"{(obj as Item).ItemPropery}" != $"{this.ItemPropery}") return false;
            return true;
        }

        public static bool operator ==(Item itemL, Item itemR) => itemL.Equals(itemR);

        public static bool operator !=(Item itemL, Item itemR) => !(itemL == itemR);
    }
}
