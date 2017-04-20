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

namespace IdeallyConnected.TestDatabases
{
    public sealed class SampleSuperstoreSection : ConfigurationSection
    {
        private static ConfigurationPropertyCollection _Properties;
        private static bool _ReadOnly;

        #region properties
        private static readonly ConfigurationProperty _CsvFilePath =
            new ConfigurationProperty("csvFilePath", typeof(string), default(string), ConfigurationPropertyOptions.IsRequired);
        private static readonly ConfigurationProperty _ExcelFilePath =
            new ConfigurationProperty("excelFilePath", typeof(string), default(string), ConfigurationPropertyOptions.None);
        private static readonly ConfigurationProperty _DatabaseName =
            new ConfigurationProperty("databaseName", typeof(string), default(string), ConfigurationPropertyOptions.IsRequired);

        [StringValidator(InvalidCharacters = "()[]{}!@#$%&*;'\",<>?")]
        public string CsvFileName
        {
            get
            {
                return (string)this["csvFilePath"];
            }
            set
            {
                ThrowIfReadOnly("CsvFilePath");
                this["csvFilePath"] = value;
            }
        }

        [StringValidator(InvalidCharacters = "()[]{}!@#$%&*;'\",<>?")]
        public string ExcelFilePath
        {
            get
            {
                return (string)this["excelFilePath"];
            }
            set
            {
                ThrowIfReadOnly("ExcelFilePath");
                this["excelFilePath"] = value;
            }
        }

        [StringValidator(InvalidCharacters = "()[]{}!@#$%&*;'\",<>?")]
        public string DatabaseName
        {
            get
            {
                return (string)this["databaseName"];
            }
            set
            {
                ThrowIfReadOnly("DatabaseName");
                this["databaseName"] = value;
            }
        }
        #endregion

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return _Properties;
            }
        }
        
        private void ThrowIfReadOnly(string propertyName)
        {
            if (IsReadOnly)
            {
                throw new ConfigurationErrorsException("The property " + propertyName + " is read only.");
            }
        }

        protected override object GetRuntimeObject()
        {
            _ReadOnly = true;
            return base.GetRuntimeObject();
        }

        private new bool IsReadOnly
        {
            get
            {
                return _ReadOnly;
            }
        }

        public SampleSuperstoreSection()
        {
            _Properties = new ConfigurationPropertyCollection();
            _Properties.Add(_CsvFilePath);
            _Properties.Add(_ExcelFilePath);
            _Properties.Add(_DatabaseName);
        }
    }

    public abstract class ContextManager
    {
        public string CSVFileLocation { get; set; }
        public string ConnectionString { get; set; }
        public string ImportProcedure { get; set; }
        public string QuickImportProcedure { get; set; }
    }

    public class Manager : ContextManager
    {
        public string Person { get; set; }
        public string Region { get; set; }
    }

    public class Order
    {
        public string OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string ShipMode { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Segment { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string ProductID { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ProductName { get; set; }
        public int Sales { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Profit { get; set; }
        public string Region { get; set; }
        public decimal ProfitRatio { get; set; }
    }

    public class Return
    {
        public string OrderID { get; set; }
        public bool Returned { get; set; }
    }

    public class SampleSuperstoreDb
    {
        private readonly string ExcelFileLocation = "C:\\Users\\kp12g_000\\Documents\\Visual Studio 2017\\Projects\\CSharpFinalProject\\SampleSuperstore.xls";
        public const string ManagersCSV = "C:\\Users\\kp12g_000\\Documents\\Visual Studio 2017\\Projects\\CSharpFinalProject\\SampleSuperstore_Managers.csv";
        public const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB; Database=SampleSuperstore; Trusted_Connection=True;";
        public const string AddManagersProcedure = "AddManagers";
        public const string AddManagersBulkImportProcedure = "AddManagersBulkImport";
        public const string AddManagerParameterName = "@ManagerData";

        public IEnumerable<Manager> Managers { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Return> Returns { get; set; }

        public SampleSuperstoreDb()
        {
            //NameValueConfigurationCollection n = new NameValueConfigurationCollection();
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
            //cobj.QuickLoadLocations();
            //SampleSuperstoreDb sampleSuperstoreDb = new SampleSuperstoreDb();
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

    }
}
