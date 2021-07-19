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

        public static string dbPath = Application.StartupPath + @"\Project\";

        static LiteDBTools()
        {
            Directory.CreateDirectory(dbPath);
        }

        public static void Update(BsonDocument content, string assemble, string dbName)
        {
            using (var db = new LiteDatabase(dbPath + dbName))
            {
                var col = db.GetCollection(assemble);

                col.Update(content);
            }
        }

        /// <summary>
        /// Creats the database .
        /// </summary>
        /// <param name="dbName">The database path.</param>
        /// <param name="assemble">The assemble.</param>
        /// <param name="firstRow">The first row.</param>
        /// <param name="id">The identifier.</param>
        public static void Creat(string dbName, string assemble, BsonDocument firstRow, string id)
        {
            using (var db = new LiteDatabase(dbPath + dbName))
            {
                var col = db.GetCollection(assemble);
                col.Insert(firstRow);
                col.EnsureIndex(id);
            }
        }

        public static void Delete(BsonDocument content, string assemble, string dbName)
        {
            using (var db = new LiteDatabase(dbPath + dbName))
            {
                var col = db.GetCollection(assemble);
                col.Delete(content);
            }
        }

        public static void Insert(BsonDocument content, string assemble, string dbName,string id=null)
        {
            using (var db = new LiteDatabase(dbPath + dbName))
            {
                var col = db.GetCollection(assemble);
                col.Insert(content);
                if (id!=null)
                {
                    
                col.EnsureIndex(id);
                }
            }
        }

        public static IEnumerable<BsonDocument> SearchAll(string assemble, string dbName)
        {
            using (var db = new LiteDatabase(dbPath + dbName))
            {
                var col = db.GetCollection(assemble);

                var customer = col.FindAll();

                return customer;
            }
        }

        public static BsonDocument SearchByID(string id, string assemble, string dbName)
        {
            using (var db = new LiteDatabase(dbPath + dbName))
            {
                var col = db.GetCollection(assemble);

                var customer = col.FindById(id);

                return customer;
            }
        }

        public static BsonDocument SearchFirst(string cmd, string assemble, string dbName)
        {
            using (var db = new LiteDatabase(dbPath + dbName))
            {
                var col = db.GetCollection(assemble);

                var customer = col.FindOne(cmd);
                return customer;
            }
        }
    }
}