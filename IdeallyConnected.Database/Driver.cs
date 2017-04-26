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

    public class MiscUtility
    {
        public static void WriteLineFormatted(string str, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(str);
            Console.ResetColor();
        }
    }

    public class Driver
    {
        public static DbManager dbManager { get; set; }
        public const string AssemblyNamespace = "IdeallyConnected.TestDatabases.";
        public static SampleSuperstoreDb sampleSuperstoreDb { get; set; }
        public static string CurrentDatabaseName { get; set; }
        public static Type CurrentDatabaseType { get; set; }
        public static dynamic dynamicDbManager { get; set; }

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

            Type dbType = Type.GetType(AssemblyNamespace + databaseName + "Db");
            CurrentDatabaseName = databaseName;
            CurrentDatabaseType = dbType;

            dynamicDbManager = Activator.CreateInstance(CurrentDatabaseType);
            dbManager = Convert.ChangeType(dynamicDbManager, CurrentDatabaseType);
            
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
            //DbManager dbman = new SampleSuperstoreDb();
            //(dbman as SampleSuperstoreDb).Managers = (List<Manager>)dbman.LoadTableFromCsv<Manager>("Managers");
            DataCollection<SampleSuperstoreDb> dbsamp = new DataCollection<SampleSuperstoreDb>();
            dbsamp.Managers = (List<Manager>)dbsamp.LoadTableFromCsv<Manager>("Managers");

            Console.WriteLine("Outputing the table data");
            foreach(Manager man in (dbsamp as SampleSuperstoreDb).Managers)
            {
                Console.WriteLine(man.Person + " " + man.Region);
            }

            Console.WriteLine("Persisting data:");
            //dbsamp.PersistTable<Manager>(dbsamp.Managers);
            dbsamp.ShowDetails();
            
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
                            dynamicDbManager.Menu();
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
