using Need_U.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Need_U
{
   public class LocalDB_User
    {
        static object locker = new object();

        SQLiteConnection database;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public LocalDB_User()
        {
            database = DependencyService.Get<IconfigSqlite>().GetConnection();
            // create the tables
            database.CreateTable<EntityUser>();
        }

        public IEnumerable<EntityUser> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<EntityUser>() select i).ToList();
            }
        }

        public IEnumerable<EntityUser> GetItemsNotDone()
        {
            lock (locker)
            {
                return database.Query<EntityUser>("SELECT * FROM [EntityUser] WHERE [Done] = 0");
            }
        }

        public EntityUser GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<EntityUser>().FirstOrDefault(x => x.IdUser == id);
            }
        }

        public long InsertUser(EntityUser item)
        {
            lock (locker)
            {
                if (item.IdUser != 0)
                {
                    database.Update(item);
                    return item.IdUser;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<EntityUser>(id);
            }
        }
    }
}

   