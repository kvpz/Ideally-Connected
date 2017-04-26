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
    using System.Reflection.Emit;

    public class Driver
    {
        public static DbManager dbManager { get; set; }
        public const string AssemblyNamespace = "IdeallyConnected.TestDatabases.";
        public static SampleSuperstore sampleSuperstoreDb { get; set; }
        public static string CurrentDatabaseName { get; set; }
        public static Type CurrentDatabaseType { get; set; }
        public static dynamic CurrentDatabase { get; set; }

        public static void Menu()
        {
            Console.WriteLine("\tA. Show available databases.");
            Console.WriteLine("\tB. Show available database servers.");
            Console.WriteLine("\tC. Select a database.");
        }

        private static bool SelectDatabase()
        {
            Console.Write("Type the desired database's name: ");
            string databaseName = Console.ReadLine().Trim();

            if (!DatabaseManager.DatabaseExists(databaseName))
            {
                WriteLineFormatted($"\t!* The database {databaseName} does not exist! *!", ConsoleColor.Red);
                return false;
            }

            if (!DatabaseManager.FeatureDatabases.Contains(databaseName))
            {
                WriteLineFormatted($"\t*** {databaseName} exists, but it is not featured. ***", ConsoleColor.DarkMagenta);
                return false;
            }

            Type dbType = Type.GetType(AssemblyNamespace + databaseName);
            CurrentDatabaseName = databaseName;
            CurrentDatabaseType = dbType;

            CurrentDatabase = Activator.CreateInstance(CurrentDatabaseType);
            dbManager = Convert.ChangeType(CurrentDatabase, CurrentDatabaseType);

            return true;
        }

        private static void Initialize()
        {
            Console.CursorSize = 50;
            Console.Title = "Database Management Tool";
        }

        private static void WriteLineFormatted(string output, ConsoleColor c)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(output);
            Console.ResetColor();
        }

        public static void Main(string[] args)
        {            
            Initialize();           
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
                        if (SelectDatabase())
                        {
                            CurrentDatabase.MainLoop();
                        }
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
