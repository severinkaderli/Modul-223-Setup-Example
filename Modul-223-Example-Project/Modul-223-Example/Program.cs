using System;

using System.Data.SQLite;
using System.IO;

namespace Modul_223_Example
{
    class Program
    {

        private static SQLiteConnection connection;
        private static string databaseName = "database.db";

        static void Main(string[] args)
        {
            // Check if database exist
            if(!File.Exists(databaseName))
            {
                Console.WriteLine("Datei existiert nicht: {0}", databaseName);
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                Environment.Exit(0);
            }

            // Connect to the database and print out all users
            connection = new SQLiteConnection("Data Source=" + databaseName + ";Version=3;");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM benutzer;", connection);
            SQLiteDataReader reader = command.ExecuteReader();
            Console.WriteLine("Benutzer:");
            while (reader.Read())
            {
                Console.WriteLine("{0}: {1}", reader["id"], reader["name"]);
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
