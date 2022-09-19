using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    internal class MongoDB
    {
        static string DBName = "UnitBase";
        static string collectionName = "Units";

        public static void AddToDB(Unit unit)
        {
            var client = new MongoClient();
            var database = client.GetDatabase(DBName);
            var collection = database.GetCollection<Unit>(collectionName);
            collection.InsertOne(unit);

        }

        public static List<Unit> FindAll()
        {
            var client = new MongoClient();
            var database = client.GetDatabase(DBName);
            var collection = database.GetCollection<Unit>(collectionName);
            var list = collection.Find(x => true).ToList();
            return list;
            /*foreach (var item in list)
            {
                //Console.WriteLine($" {item?.Name} {item?.Email} {item?.Age} {item?.DriverCard}");
            }*/

        }

        public static Unit Find(string name)
        {
            var client = new MongoClient();
            var database = client.GetDatabase(DBName);
            var collection = database.GetCollection<Unit>(collectionName);
            var one = collection.Find(x => x.Name == name).FirstOrDefault();
            return one;
            //Console.WriteLine($" {one?.Name} {one?.Email} {one?.Age} {one?.DriverCard}");


        }
    }
}
