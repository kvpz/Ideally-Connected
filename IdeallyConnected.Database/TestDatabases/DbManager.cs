using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Office.Interop.Excel;
using System.Data;

namespace IdeallyConnected.TestDatabases
{
    using IdeallyConnected.TestDatabases.Configurations;
    using System.Data.SqlClient;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
    using System.IO;
    using System.Reflection;
    using CsvHelper;
    using IdeallyConnected.DatabaseManager.Tools;
    using CsvHelper.Configuration;

    /// <summary>
    /// A class intended to be inherited by a class representing a single database. The class provides
    /// the usual functionality required to interact with the database. This is equivalent to a data adapter, or
    /// the "mapping" object in the ORM technique.
    /// </summary>
    public abstract class DbManager : IDbManager
    {
        public string ConnectionString { get; set; }
        public string DataSource { get; set; }
        public string DatabaseName { get; set; }
        public Dictionary<string, string> CsvFilePaths { get; set; }
        private Database _database { get; set; }
        public IReadOnlyCollection<string> FeaturedProcedures { get; set; }
        protected Dictionary<string, Dictionary<ProcedureType, string>> FeaturedProceduresDictionary { get; set; }
        public enum ProcedureType { Create, Read, Update, Delete }

        private DbManager()
        {
        }

        protected DbManager(string databaseName) : this()
        {
            DatabaseName = databaseName;

            DbConfigSection config = (DbConfigSection)ConfigurationManager.GetSection("TestDatabases/" + databaseName);
            ConnectionString = config.DatabaseConfig.ConnectionString;

            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(ConnectionString);
            DataSource = connectionStringBuilder.DataSource;

            ServerConnection serverConnection = new ServerConnection(DataSource);
            serverConnection.DatabaseName = DatabaseName;

            Server server = new Server(serverConnection);
            _database = server.Databases[DatabaseName];

            UpdateProcedures();

            CsvFilePaths = new Dictionary<string, string>();
            foreach (TableElement t in config.Tables)
            {
                if (t.Name.Length > 1)
                {
                    CsvFilePaths.Add(t.Name, t.CsvFile);
                }
            }
        }

        public virtual DataSet<T> Set<T>(Type tableType) where T : class, new()
        {
            if(tableType.Name == DatabaseName)
            {
                throw new Exception("A DataSet cannot be created from database model class.");
            }

            return Activator.CreateInstance<DataSet<T>>();
        }

        /// <summary>
        /// Load an entire table's data from the current database. An IEnumerable representing the table records is returned.
        /// Note that the first element of the list returned may represent the table's column names.
        /// </summary>
        /// <typeparam name="TableType"></typeparam>
        /// <param name="tableName">The name of the table/ model as defined in the C# class.</param>
        /// <returns></returns>
        public virtual IEnumerable<TableType> LoadTableFromCsv<TableType>(string tableName) where TableType : Model<TableType>, new()
        {
            // Connect with the CSV file
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvFilePath = 
                CsvFilePaths.ContainsKey(typeof(TableType).Name + "s") ? CsvFilePaths[typeof(TableType).Name + "s"] : CsvFilePaths[typeof(TableType).Name];

            StreamReader csvStream = File.OpenText(CsvFilePaths[typeof(TableType).Name + "s"]);
            CsvReader csvReader = new CsvReader(csvStream);
            CsvConfiguration csvConfig = new CsvConfiguration();
            
            // Read data from the CSV
            TableType tableModel = new TableType();
            List<TableType> table = new List<TableType>();

            // check if the first record represents the table columns
            csvReader.Configuration.HasHeaderRecord = false;
            csvReader.Read();
            HashSet<string> tableAttributes = new HashSet<string>(new List<string>(typeof(TableType).GetProperties().Select(prop => prop.Name)));
            foreach(string element in csvReader.CurrentRecord)
            {
                if (tableAttributes.Contains(element))
                {
                    csvReader.Configuration.HasHeaderRecord = true;
                    break;
                }
            }

            if (csvReader.Configuration.HasHeaderRecord == false)
            {
                tableModel = Model<TableType>.TInitialize(csvReader.CurrentRecord);
                table.Add(tableModel);
            }

            // Read the rest of the records
            while (csvReader.Read())
            {
                tableModel = Model<TableType>.TInitialize(csvReader.CurrentRecord);
                table.Add(tableModel);
            }

            return table;
        } 

        public virtual void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("\tbA. generic base option");
        }

        /// <summary>
        /// Insert data into the table using procedure stored in the database.
        /// </summary>
        /// <typeparam name="T">The name of model class representing a database table.</typeparam>
        /// <param name="data">The table records to be inserted into the database.</param>
        /// <param name="importProcedure">The name of the database procedure used to insert data.</param>
        public virtual void Insert<T>(List<T> data, string importProcedure = default(string)) where T : Model<T>, new()
        {
            Dictionary<string, Type> TableAttributes = new Dictionary<string, Type>();
            PropertyInfo[] managerProperties = Model<T>.GetProperties();
            foreach (PropertyInfo prop in managerProperties)
            {
                TableAttributes.Add(prop.Name, prop.PropertyType);
            }

            if(importProcedure == null)
            {
                try
                {
                    importProcedure = GetTableProcedure(ProcedureType.Update, typeof(T).Name);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Can't find any procedures for updating the table.");
                    return;
                }
            }

            CSVParser cobj = new CSVParser();
            cobj.QuickImport<T>(
                data,
                ConnectionString,
                importProcedure,
                "@" + typeof(T).Name,
                "Managers",
                TableAttributes);
        }

        /// <summary>
        /// Print details about the database.
        /// </summary>
        public virtual void ShowDetails()
        {
            Console.WriteLine($"\tConnection String: \"{ConnectionString}\"");
            int totalProcedures = FeaturedProcedures.Aggregate(0, (accum, kv) => accum += 1, accum => accum);
            Console.WriteLine($"\tTotal procedures: {totalProcedures}");
        }

        /// <summary>
        /// Update the current list of user defined procedures found in the database. 
        /// </summary>
        public virtual void UpdateProcedures()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                System.Data.DataTable dt = connection.GetSchema("Procedures");
                SortedSet<string> featuredProcedures = new SortedSet<string>();
                foreach (DataRow row in dt.Rows)
                {
                    featuredProcedures.Add((string)row[row.Table.Columns["ROUTINE_NAME"]]);
                }
                FeaturedProcedures = featuredProcedures;
                connection.Close();
            }
        }

        /// <summary>
        /// Create a dictionary of procedures organized by tables and the type of procedure. Unidentifiable
        /// procedures would be stored as miscellaneous.
        /// </summary>
        /// <param name="procedureType"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public virtual string GetTableProcedure(ProcedureType procedureType, string tableName)
        {
            if(FeaturedProceduresDictionary == null)
            {
                throw new System.Exception("There are no featured procedures for this database.");
            }
            if (!FeaturedProceduresDictionary.ContainsKey(tableName))
            {
                throw new System.Exception("The table is not defined in the FeaturedProceduresDictionary.");
            }
            if (!FeaturedProceduresDictionary[tableName].ContainsKey(procedureType))
            {
                throw new System.Exception($"The procedureType is not defined for the table {tableName}.");
            }

            return FeaturedProceduresDictionary[tableName][procedureType];
        }

        public void ViewProcedures()
        {
            foreach(string procedure in FeaturedProcedures)
            {
                Console.WriteLine(procedure);
            }
        }
    }
}
