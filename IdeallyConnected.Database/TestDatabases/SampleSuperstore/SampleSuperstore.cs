using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IdeallyConnected.DatabaseManager.Tools;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace IdeallyConnected.TestDatabases
{
    public abstract class ContextManager
    {
        public string CSVFileLocation { get; set; }
        public string ConnectionString { get; set; }
        public string ImportProcedure { get; set; }
        public string QuickImportProcedure { get; set; }
    }

    /// <summary>
    /// This class maintains the structure and any special functionality required by the database
    /// it represents. This is equivalent to a data set, or the "Relational Database Object" in the
    /// Object Relational Modeling technique.
    /// </summary>
    public class SampleSuperstore : DbManager
    {
        //private readonly string ExcelFileLocation = "C:\\Users\\kp12g_000\\Documents\\Visual Studio 2017\\Projects\\CSharpFinalProject\\SampleSuperstore.xls";
        //public const string ManagersCSV = "C:\\Users\\kp12g_000\\Documents\\Visual Studio 2017\\Projects\\CSharpFinalProject\\SampleSuperstore_Managers.csv";
        //public readonly string ConnectionString = "Server=(localdb)\\MSSQLLocalDB; Database=SampleSuperstore; Trusted_Connection=True;";
        public readonly string AddManagersProcedure = "AddManagers";
        public readonly string AddManagersBulkImportProcedure = "AddManagersBulkImport";
        public readonly string OrderBulkImport = "OrdersBulkImport";
        public readonly string AddManagerParameterName = "@ManagerData";

        public DataSet<Manager> Managers { get; set; }
        public DataSet<Order> Orders { get; set; }
        public DataSet<Return> Returns { get; set; }

        public SampleSuperstore()
            : base("SampleSuperstore")
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            Managers = new DataSet<Manager>();
            Orders = new DataSet<Order>();
            Returns = new DataSet<Return>();
        }

        public void MainLoop()
        {
            Menu();
            string selection = "m";
            bool loop = true;
            do
            {
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "a": case "A":
                        Managers = (List<Manager>)LoadTableFromCsv<Manager>("Manager");
                        MiscUtility.WriteLineFormatted($"Added {Managers.Count()} managers onto the stack.\n", ConsoleColor.Green);
                        break;
                    case "b": case "B":
                        try
                        {
                            InsertManagers();
                            MiscUtility.WriteLineFormatted($"Inserted {Managers.Count()} records into the database.", ConsoleColor.Green);
                            Managers.Clear();
                        }
                        catch (SqlException e)
                        {
                            MiscUtility.WriteLineFormatted(e.Message, ConsoleColor.Red);
                        }
                        break;
                    case "c": case "C":
                        Orders = (List<Order>)LoadTableFromCsv<Order>("Order");
                        MiscUtility.WriteLineFormatted($"Added {Orders.Count()} orders onto the stack.\n", ConsoleColor.Green);
                        break;
                    case "d": case "D":
                        try
                        {
                            InsertOrders();
                            MiscUtility.WriteLineFormatted($"Inserted {Orders.Count()} records into the database.", ConsoleColor.Green);
                            Orders.Clear();
                        }
                        catch (SqlException e)
                        {
                            MiscUtility.WriteLineFormatted(e.Message, ConsoleColor.Red);
                        }
                        break;
                    case "m": case "M":
                        Menu();
                        break;
                    case "q": case "Q":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection.\n");
                        Menu();
                        break;
                }
                Console.WriteLine();
            } while (loop);
        }

        public override void Menu()
        {
            Console.WriteLine("Menu from SampleSuperstore");
            base.Menu();
            Console.WriteLine("\tA. Load Manager data from CSV");
            Console.WriteLine("\tB. Insert Manager data into database");
            Console.WriteLine("\tC. Load Order data from CSV");
            Console.WriteLine("\tD. Insert Order data into database");
            Console.WriteLine("\tQ. Go back");
        }

        public void InsertManagers()
        {
            Dictionary<string, Type> ManagerAttributes = new Dictionary<string, Type>();

            PropertyInfo[] managerProperties = typeof(Manager).GetProperties();
            foreach (PropertyInfo prop in managerProperties)
            {
                ManagerAttributes.Add(prop.Name, prop.PropertyType);
            }

            QuickImport<Manager>(
                LoadTableFromCsv<Manager>("Manager").ToList(),
                ConnectionString,
                AddManagersBulkImportProcedure,
                AddManagerParameterName,
                "Managers",
                ManagerAttributes);
        }

        public void InsertOrders()
        {
            Dictionary<string, Type> OrderAttributes = new Dictionary<string, Type>();

            PropertyInfo[] orderProperties = typeof(Order).GetProperties();
            foreach(PropertyInfo property in orderProperties)
            {
                OrderAttributes.Add(property.Name, property.PropertyType);
            }

            QuickImport<Order>(
                LoadTableFromCsv<Order>("Order").ToList(),
                ConnectionString,
                OrderBulkImport,
                "@OrderData",
                "Orders",
                OrderAttributes
                );
        }

        public override void ShowDetails()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t$$$ SampleSuperstore Details $$$");
            Console.ResetColor();
            base.ShowDetails();
            Console.WriteLine();
        }
    }
}
