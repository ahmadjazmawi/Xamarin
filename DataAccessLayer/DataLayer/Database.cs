using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility.Logs;

namespace DataAccessLayer.DL
{
    public class Database : SQLiteConnection
    {
        static object locker = new object();

        /// <summary>
        /// Initializes a new instance of the Database. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public Database(string path) : base(path, true, "Password")
        {
            try
            {
                LogsHandler.WriteDebug("CreateTable MainTable");

                // create the tables
                CreateTable<DataAccessLayer.Models.Tables.MainTable>();
            }
            catch (Exception Ex)
            {
                LogsHandler.WriteException(Ex);
            }
        }

        public IEnumerable<T> GetItems<T>() where T : Models.Contracts.IBusinessEntity, new()
        {
            lock (locker)
            {
                return (from i in Table<T>() select i).ToList();
            }
        }

        public T GetItem<T>(int id) where T : Models.Contracts.IBusinessEntity, new()
        {
            lock (locker)
            {
                return Table<T>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveItem<T>(T item) where T : Models.Contracts.IBusinessEntity
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    Update(item);
                    return item.ID;
                }
                else
                {
                    return Insert(item);
                }
            }
        }

        public int DeleteItem<T>(int id) where T : Models.Contracts.IBusinessEntity, new()
        {
            lock (locker)
            {
                return Delete(new T() { ID = id });
            }
        }

        public int DeleteAllItems<T>() where T : Models.Contracts.IBusinessEntity, new()
        {
            lock (locker)
            {
                return DeleteAll<T>();
            }
        }

        public void Tables<T>() where T : Models.Contracts.IBusinessEntity, new()
        {
            var x = Table<T>();
        }
    }
}
