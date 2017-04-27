using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Data;
using System.Data.Sql;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Xml.Linq;
using System.Configuration;

namespace IdeallyConnected.DatabaseManager
{
    using IdeallyConnected.TestDatabases.Configurations;
    using Microsoft.SqlServer.Management.Smo;
    using System.Collections.Specialized;
    using System.Data.SqlClient;

    /// <summary>
    /// This static class handles the metadata associated with databases and their servers. 
    /// </summary>
    public static class DatabaseManager
    {
        public static Dictionary<string, SortedSet<string>> Servers { get; private set; }
        public static HashSet<string> FeatureDatabases { get; set; }

        static DatabaseManager()
        {
            Servers = new Dictionary<string, SortedSet<string>>();

            foreach(ConnectionStringSettings cstr in ConfigurationManager.ConnectionStrings)
            {
                SqlConnectionStringBuilder connStrBuilder = new SqlConnectionStringBuilder(cstr.ConnectionString);
                if (!Servers.ContainsKey(connStrBuilder.DataSource))
                {
                    Servers[connStrBuilder.DataSource] = new SortedSet<string>();

                    Server server = new Server(connStrBuilder.DataSource);
                    foreach(Database db in server.Databases)
                    {
                        Servers[connStrBuilder.DataSource].Add(db.ToString());
                    }
                }
                else
                    Servers[connStrBuilder.DataSource].Add(connStrBuilder.InitialCatalog);
            }

            FeatureDatabases = new HashSet<string>();
            
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            foreach(ConfigurationSection cs in config.GetSectionGroup("TestDatabases").Sections)
            {
                FeatureDatabases.Add(cs.SectionInformation.Name);
            }
        }

        public static void ShowDatabases()
        {
            Console.WriteLine("Databases: ");
            foreach(SortedSet<string> serverDbs in Servers.Values)
            {
                foreach(string db in serverDbs)
                {
                    Console.WriteLine($"\t{db}");
                }
            }
        }

        public static void ShowServers()
        {
            Console.WriteLine("Servers:");
            foreach(string server in Servers.Keys)
            {
                Console.WriteLine($"\t{server}");
            }
        }

        public static bool DatabaseExists(string databaseName)
        {
            foreach(KeyValuePair<string, SortedSet<string>> server in Servers)
            {
                if (server.Value.Contains(databaseName))
                    return true;
            }

            return false;
        }
    }
}
