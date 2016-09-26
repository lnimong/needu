using Need_U.iOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(configSqLiteIos))]
namespace Need_U.iOS
{
   public class configSqLiteIos : IconfigSqlite
    {
            public configSqLiteIos() { }

            public SQLite.SQLiteConnection GetConnection()
            {
                var sqliteFilename = "TodoSQLite.db3";
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
                var path = Path.Combine(libraryPath, sqliteFilename);
                // Create the connection
                var conn = new SQLite.SQLiteConnection(path);
                // Return the database connection
                return conn;
            }
        










    }
}
