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
    public class SampleSuperstoreDb : DbManager
    {
        //private readonly string ExcelFileLocation = "C:\\Users\\kp12g_000\\Documents\\Visual Studio 2017\\Projects\\CSharpFinalProject\\SampleSuperstore.xls";
        //public const string ManagersCSV = "C:\\Users\\kp12g_000\\Documents\\Visual Studio 2017\\Projects\\CSharpFinalProject\\SampleSuperstore_Managers.csv";
        //public readonly string ConnectionString = "Server=(localdb)\\MSSQLLocalDB; Database=SampleSuperstore; Trusted_Connection=True;";
        public readonly string AddManagersProcedure = "AddManagers";
        public readonly string AddManagersBulkImportProcedure = "AddManagersBulkImport";
        public readonly string AddManagerParameterName = "@ManagerData";

        public DataCollection<Manager> Managers { get; set; }
        public DataCollection<Order> Orders { get; set; }
        public DataCollection<Return> Returns { get; set; }

        public SampleSuperstoreDb()
            : base("SampleSuperstore")
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            Managers = new DataCollection<Manager>();
            Orders = new DataCollection<Order>();
            Returns = new DataCollection<Return>();
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
            } while (loop);
        }

        public override void Menu()
        {
            Console.WriteLine("Menu from SampleSuperstoreDb");
            base.Menu();
            Console.WriteLine("\tA. Load Managers data from CSV");
            Console.WriteLine("\tQ. Go back");
        }

        public void InsertManagers()
        {
            CSVParser cobj = new CSVParser();
            Dictionary<string, Type> ManagerAttributes = new Dictionary<string, Type>();
            Manager managerObj = new Manager();
            //Type ManagerTypes = Assembly.GetAssembly(managerObj.GetType());
            PropertyInfo[] managerProperties = managerObj.GetType().GetProperties();
            foreach (PropertyInfo prop in managerProperties)
            {
                Console.WriteLine(prop.Name);
                Console.WriteLine(prop.PropertyType.Name);
                ManagerAttributes.Add(prop.Name, prop.PropertyType);
            }

            cobj.QuickImport<Manager>(
                LoadTableFromCsv<Manager>("Manager").ToList(),
                ConnectionString,
                AddManagersBulkImportProcedure,
                AddManagerParameterName,
                "Managers",
                ManagerAttributes);
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
