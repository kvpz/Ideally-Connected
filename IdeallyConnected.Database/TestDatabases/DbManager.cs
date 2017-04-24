using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Office.Interop.Excel;

namespace IdeallyConnected.TestDatabases
{
    using IdeallyConnected.TestDatabases.Configurations;
    using System.Data.SqlClient;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
    using System.Data;
    using System.IO;
    using System.Reflection;
    using CsvHelper;
    using IdeallyConnected.DatabaseManager.Tools;

    /// <summary>
    /// A class intended to be inherited by a class representing a single database. The class provides
    /// the usual functionality required to interact with the database. This is equivalent to a data adapter.
    /// </summary>
    public abstract class DbManager : IDbManager
    {
        public string ConnectionString { get; set; }
        public string DataSource { get; set; }
        public string DatabaseName { get; set; }
        public Dictionary<string, string> CsvFilePaths { get; set; }
        public Database _database { get; set; }
        public IReadOnlyCollection<string> FeaturedProcedures { get; set; }
        protected Dictionary<string, Dictionary<ProcedureType, string>> FeaturedProceduresDictionary { get; set; }
        public enum ProcedureType { Create, Read, Update, Delete }

        private DbManager()
        {
            Console.WriteLine("In DbManager Private Constructor");
        }

        protected DbManager(string databaseName) : this()
        {
            DbConfigSection config = (DbConfigSection)ConfigurationManager.GetSection("TestDatabases/" + databaseName);
            ConnectionString = config.DatabaseConfig.ConnectionString;

            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(ConnectionString);
            DataSource = connectionStringBuilder.DataSource;
            DatabaseName = databaseName;
            ServerConnection serverConnection = new ServerConnection(DataSource);
            serverConnection.DatabaseName = databaseName;
            Server server = new Server(serverConnection);
            _database = server.Databases[databaseName];

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

        public virtual IEnumerable<TableType> LoadTableFromCsv<TableType>(string tableName) where TableType : IModel<TableType>, new()
        {
            TableType tableModel = new TableType(); 
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            List<TableType> table = new List<TableType>();
            StreamReader csvStream = File.OpenText(CsvFilePaths[typeof(TableType).Name + "s"]);
            CsvReader csvReader = new CsvReader(csvStream);

            if (csvReader.Configuration.HasHeaderRecord == false) // assuming first row is truly a header
                csvReader.Read();
            
            while (csvReader.Read())
            {
                tableModel = IModel<TableType>.TInitialize(csvReader.CurrentRecord);
                table.Add(tableModel);
            }

            return table;
        } 

        public virtual void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("\tbA. generic base option");
            
        }

        public virtual void PersistTable<T>(List<T> data) where T : IModel<T>, new()
        {
            CSVParser cobj = new CSVParser();
            Dictionary<string, Type> ManagerAttributes = new Dictionary<string, Type>();
            T managerObj = new T();
            PropertyInfo[] managerProperties = managerObj.GetType().GetProperties();
            foreach (PropertyInfo prop in managerProperties)
            {
                Console.WriteLine(prop.Name);
                Console.WriteLine(prop.PropertyType.Name);
                ManagerAttributes.Add(prop.Name, prop.PropertyType);
            }

            cobj.QuickLoad<T>(
                data,
                ConnectionString,
                GetTableProcedure(ProcedureType.Update, typeof(T).Name),
                "@" + typeof(T).Name,
                "Managers",
                ManagerAttributes);
        }

        /// <summary>
        /// Print details about the database.
        /// </summary>
        public virtual void ShowDetails()
        {
            Console.WriteLine($"\tConnection String: \"{ConnectionString}\"");
            //int totalProcedures = Procedures.Aggregate(0, (accum, kv) => accum += kv.Value.Count, accum => accum);
            //Console.WriteLine($"\tTotal procedures: {totalProcedures}");
        }

        /// <summary>
        /// Update the current list of procedures found in the database.
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

        public virtual string GetTableProcedure(ProcedureType procedureType, string tableName)
        {
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
