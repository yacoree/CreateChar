using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    public static class MongoExample
    {
        static string DBName = "UnitsBase";
        static string collectionName = "Units";
        static MongoClient client;
        static IMongoDatabase database;
        static IMongoCollection<Unit> collection;

        static MongoExample()
        {
            client = new MongoClient();
            database = client.GetDatabase(DBName);
            collection = database.GetCollection<Unit>(collectionName);
        }

        public static void AddToDB(Unit unit)
        {
            collection.InsertOne(unit);
        }

        public static List<Unit> FindAll()
        {
            List<Unit> res = new List<Unit>();
            foreach (var i in UnitClass("Rogue")) res.Add(i);
            foreach (var i in UnitClass("Wizard")) res.Add(i);
            foreach (var i in UnitClass("Warrior")) res.Add(i);
            return res;

        }

        public static void ReplaceUnit(string name, Unit unit)
        {
            collection.ReplaceOne(x => x.Name == name, unit);
        }

        public static Unit Find(string name)
        {
            var one = collection.Find(x => x.Name == name).FirstOrDefault();
            return one;
        }

        private static List<Unit> UnitClass(string unitClass)
        {
            List<Unit> res = new List<Unit>();
            var filter = new BsonDocument("_t", unitClass);
            var list = collection.Find(filter).ToList();
            foreach (var item in list)
            {
                res.Add(UnitMaker.TransformUnit(unitClass, item));
            }
            return list;
        }
    }
}
