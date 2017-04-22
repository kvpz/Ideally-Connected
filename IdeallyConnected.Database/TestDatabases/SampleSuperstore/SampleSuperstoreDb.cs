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

namespace IdeallyConnected.TestDatabases.SampleSuperstore
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
    /// it represents. This is equivalent to a data set.
    /// </summary>
    public class SampleSuperstoreDb : DbManager
    {
        //private readonly string ExcelFileLocation = "C:\\Users\\kp12g_000\\Documents\\Visual Studio 2017\\Projects\\CSharpFinalProject\\SampleSuperstore.xls";
        public const string ManagersCSV = "C:\\Users\\kp12g_000\\Documents\\Visual Studio 2017\\Projects\\CSharpFinalProject\\SampleSuperstore_Managers.csv";
        //public readonly string ConnectionString = "Server=(localdb)\\MSSQLLocalDB; Database=SampleSuperstore; Trusted_Connection=True;";
        public readonly string AddManagersProcedure = "AddManagers";
        public readonly string AddManagersBulkImportProcedure = "AddManagersBulkImport";
        public readonly string AddManagerParameterName = "@ManagerData";

        public IEnumerable<Manager> Managers { get; set; }
        public Order Orders { get; set; }
        public Return Returns { get; set; }
        /*
        private SampleSuperstoreDb()
        {
            Manager.CsvFilePath = CsvFilePaths["Manager"];
            Managers = new List<Manager>();
            Order.CsvFilePath = CsvFilePaths["Order"];
            
        }
        */
        public SampleSuperstoreDb()
            : base("SampleSuperstore")
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
        }

        public List<Manager> LoadManagersFromCSV(string fileLocation = ManagersCSV)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            List<Manager> result = new List<Manager>();
            StreamReader csvStream = File.OpenText(ManagersCSV);
            CsvReader csvReader = new CsvReader(csvStream);
            if(csvReader.Configuration.HasHeaderRecord == false) // assuming first row is truly a header
                csvReader.Read();

            while (csvReader.Read())
            {
                Manager record = new Manager();
                record.Person = csvReader.GetField(0);
                record.Region = csvReader.GetField(1);
                result.Add(record); 
            }

            return result;
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

            cobj.QuickLoad<Manager>(
                LoadManagersFromCSV(),
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
