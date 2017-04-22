using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Database
{
    using IdeallyConnected.TestDatabases;
    using System.Reflection;
    using IdeallyConnected.DatabaseManager;
    using System.IO;
    using IdeallyConnected.TestDatabases.Configurations;
    using IdeallyConnected.TestDatabases.SampleSuperstore;

    public class Driver
    {
        public static void Menu()
        {
            Console.WriteLine("\tA. Show available databases.");
            Console.WriteLine("\tB. Show available database servers.");
            Console.WriteLine("\tC. Select a database.");
        }

        private static void SelectDatabase()
        {
            Console.Write("Type the database name: ");
            string databaseName = Console.ReadLine().Trim();
            if (!DatabaseManager.DatabaseExists(databaseName))
            {
                WriteLineFormatted($"\t!* The database {databaseName} does not exist! *!", ConsoleColor.Red);
                return;
            }

            if (!DatabaseManager.FeatureDatabases.Contains(databaseName))
            {
                WriteLineFormatted($"\t*** {databaseName} exists, but it is not featured. ***", ConsoleColor.DarkMagenta);
                return;
            }
        }

        private static void SetOutputFormat()
        {
            Console.CursorSize = 50;
            Console.Title = "IdeallyConnected Database Management";
        }

        private static void WriteLineFormatted(string output, ConsoleColor c)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(output);
            Console.ResetColor();
        }

        public static void Main(string[] args)
        {
            SetOutputFormat();

            SampleSuperstoreDb sampleSuperStore = new SampleSuperstoreDb();
            DbManager db = new SampleSuperstoreDb();
            
            WriteLineFormatted("\t~~~ Database Manager ~~~\n", ConsoleColor.DarkGreen);
            char menuSelection = 'm';
            bool programLoop = true;
            do
            {
                switch(menuSelection)
                {
                    case 'a': case 'A':
                        DatabaseManager.ShowDatabases();
                        break;
                    case 'b': case 'B':
                        DatabaseManager.ShowServers();
                        break;
                    case 'c': case 'C':
                        SelectDatabase();
                        break;
                    case 'q': case 'Q':
                        programLoop = false;
                        break;
                    case 'm': case 'M':
                    default:
                        Menu();
                        break;
                }
            } while (programLoop && (menuSelection = Console.ReadLine().FirstOrDefault()) != 'q');
        }
    }
}
