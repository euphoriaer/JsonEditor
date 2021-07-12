using LiteDB;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace JsonShow.Scripts.Tools
{
    public static class LiteDBTools
    {
        //new BsonDocument()
        //{
        //    ["_id"]= 1,["Name"]= "John Doe"
        //}

        public static string dbPath = Application.StartupPath + @"\DataBase\";

        static LiteDBTools()
        {
            Directory.CreateDirectory(dbPath);
        }

        public static void Update(BsonDocument content, string collection, string dbName)
        {
            using (var db = new LiteDatabase(dbPath + dbName))
            {
                var col = db.GetCollection(collection);

                col.Update(content);
            }
        }

        /// <summary>
        /// Creats the database .
        /// </summary>
        /// <param name="dbName">The database path.</param>
        /// <param name="collection">The collection.</param>
        /// <param name="firstRow">The first row.</param>
        /// <param name="id">The identifier.</param>
        public static void Creat(string dbName, string collection, BsonDocument firstRow, string id)
        {
            using (var db = new LiteDatabase(dbPath + dbName))
            {
                var col = db.GetCollection(collection);
                col.Insert(firstRow);
                col.EnsureIndex(id);
            }
        }

        public static void Delete(BsonDocument content, string collection, string dbName)
        {
            using (var db = new LiteDatabase(dbPath + dbName))
            {
                var col = db.GetCollection(collection);
                col.Delete(content);
            }
        }

        public static void Insert(BsonDocument content, string collection, string dbName)
        {
            using (var db = new LiteDatabase(dbPath + dbName))
            {
                var col = db.GetCollection(collection);
                col.Insert(content);
            }
        }

        public static IEnumerable<BsonDocument> SearchAll(string collection, string dbName)
        {
            using (var db = new LiteDatabase(dbPath + dbName))
            {
                var col = db.GetCollection(collection);

                var customer = col.FindAll();

                return customer;
            }
        }

        public static BsonDocument SearchByID(string id, string collection, string dbName)
        {
            using (var db = new LiteDatabase(dbPath + dbName))
            {
                var col = db.GetCollection(collection);

                var customer = col.FindById(id);

                return customer;
            }
        }

        public static BsonDocument SearchFirst(string cmd, string collection, string dbName)
        {
            using (var db = new LiteDatabase(dbPath + dbName))
            {
                var col = db.GetCollection(collection);

                var customer = col.FindOne(cmd);
                return customer;
            }
        }
    }
}