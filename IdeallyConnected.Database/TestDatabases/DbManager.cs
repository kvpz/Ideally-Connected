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

        private DbManager()
        {
            
        }

        protected DbManager(string databaseName)
        {
            TestDbConfigSection config = (TestDbConfigSection)ConfigurationManager.GetSection("TestDatabases/" + databaseName);
            ConnectionString = config.DatabaseConfig.ConnectionString;

            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(ConnectionString);
            DataSource = connectionStringBuilder.DataSource;
            DatabaseName = databaseName;
            ServerConnection serverConnection = new ServerConnection(DataSource);
            serverConnection.DatabaseName = databaseName;
            Server server = new Server(serverConnection);
            _database = server.Databases[databaseName];

            UpdateProcedures();

            Console.WriteLine(config.Tables);
        }

        public virtual void LoadTableFromCsv<TableType>(string tableName) where TableType : DbTable, new()
        {
            TableType table = new TableType();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            List<TableType> result = new List<TableType>();
            StreamReader csvStream = File.OpenText(CsvFilePaths[tableName]);
            CsvReader csvReader = new CsvReader(csvStream);
            if (csvReader.Configuration.HasHeaderRecord == false) // assuming first row is truly a header
                csvReader.Read();

            while (csvReader.Read())
            {
                table = new TableType();
                //table.Person = csvReader.GetField(0);
                //table.Region = csvReader.GetField(1);
                result.Add(table);
            }
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

        public void ViewProcedures()
        {
            foreach(string procedure in FeaturedProcedures)
            {
                Console.WriteLine(procedure);
            }
        }
    }
}
