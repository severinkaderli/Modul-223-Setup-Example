using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Modul_223_Example
{
    class Program
    {

        private static SQLiteConnection connection;
        private static String databaseName = "database.db";

        static void Main(string[] args)
        {
            // Check if database exist
            if(!File.Exists(databaseName))
            {
                System.Console.WriteLine("Datei existiert nicht: " + databaseName);
                System.Console.WriteLine("Press any key to exit");
                System.Console.ReadLine();
                Environment.Exit(0);
            }

            // Connect to the database and print out all users
            connection = new SQLiteConnection("Data Source=" + databaseName + ";Version=3;");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM benutzer;", connection);
            SQLiteDataReader reader = command.ExecuteReader();
            System.Console.WriteLine("Benutzer:");
            while (reader.Read())
                Console.WriteLine(reader["id"] + ": " + reader["name"]);

            System.Console.ReadLine();
        }
    }
}
