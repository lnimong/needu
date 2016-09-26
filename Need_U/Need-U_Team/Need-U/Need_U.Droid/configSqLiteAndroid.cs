using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Need_U.Droid;
using System.IO;

[assembly: Dependency(typeof(configSqLiteAndroid))]

namespace Need_U.Droid
{
   public class configSqLiteAndroid :IconfigSqlite
    {
            public configSqLiteAndroid() { }


            public SQLite.SQLiteConnection GetConnection()
            {
                var sqliteFilename = "NeedUSqlite.db3";
                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
                var path = Path.Combine(documentsPath, sqliteFilename);
                // Create the connection
                var conn = new SQLite.SQLiteConnection(path);
                // Return the database connection
                return conn;
            }
        
        
    }
}