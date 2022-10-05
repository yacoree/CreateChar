using MongoDB.Driver;

namespace CreateChar
{
    public static class MongoExample
    {
        static string dataBaseName = "UnitsBase";
        static string unitCollectionName = "Units";
        static string itemCollectionName = "Items";
        static MongoClient client;
        static IMongoDatabase database;
        static IMongoCollection<Unit> unitCollection;
        static IMongoCollection<Item> itemCollection;

        static MongoExample()
        {
            client = new MongoClient();
            database = client.GetDatabase(dataBaseName);
            unitCollection = database.GetCollection<Unit>(unitCollectionName);
            itemCollection = database.GetCollection<Item>(itemCollectionName);
        }

        public static void AddUnitTodataBase(Unit unit)
        {
            unitCollection.InsertOne(unit);
        }

        public static void AddItemTodataBase(Item item)
        {
            itemCollection.InsertOne(item);
        }

        public static List<Unit> FindAllUnits()
        {
            return unitCollection.Find(x => true).ToList();
        }

        public static List<Item> FindAllItems()
        {
            return itemCollection.Find(x => true).ToList();
        }

        public static void ReplaceUnit(string name, Unit unit)
        {
            unitCollection.ReplaceOne(x => x.Name == name, unit);
        }
        public static void ReplaceItem(string name, Item item)
        {
            itemCollection.ReplaceOne(x => x.ItemName == name, item);
        }

        public static Unit FindUnit(string name)
        {
            return unitCollection.Find(x => x.Name == name).FirstOrDefault();
        }

        public static Item Finditem(string name)
        {
            return itemCollection.Find(x => x.ItemName == name).FirstOrDefault();
        }
    }
}
