using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
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
        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId id;

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

        public bool EqualItem(Item comparedItem)
        {
            if (comparedItem == null) return false;
            if (comparedItem.ItemName != this.ItemName) return false;
            if (comparedItem.ItemWeight != this.ItemWeight) return false;
            if ($"{comparedItem.ItemPropery}" != $"{this.ItemPropery}") return false;
            return true;
        }
    }
}
