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
    using Microsoft.SqlServer.Management.Smo;
    using System.Collections.Specialized;
    using System.Data.SqlClient;

    public class DatabaseManager
    {
        public Dictionary<string, HashSet<string>> Servers { get; private set; }

        public DatabaseManager()
        {
            Servers = new Dictionary<string, HashSet<string>>();

            ConnectionStringSettingsCollection connStrCol = ConfigurationManager.ConnectionStrings;
            foreach(ConnectionStringSettings cstr in connStrCol)
            {
                SqlConnectionStringBuilder connStrBuilder = new SqlConnectionStringBuilder(cstr.ConnectionString);
                if (!Servers.ContainsKey(connStrBuilder.DataSource))
                {
                    Servers[connStrBuilder.DataSource] = new HashSet<string>();
                    if (connStrBuilder.InitialCatalog.Length > 1)
                        Servers[connStrBuilder.DataSource].Add(connStrBuilder.InitialCatalog);
                }
                else
                    Servers[connStrBuilder.DataSource].Add(connStrBuilder.InitialCatalog);
            }
            /*
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            Console.WriteLine(appSettings.ToString());
            foreach(string s in appSettings.AllKeys)
            {
                Console.WriteLine(appSettings[s]);
            }
            */
        }

        public void ShowDatabases()
        {
            Console.WriteLine("Databases: ");
            foreach(HashSet<string> serverDbs in Servers.Values)
            {
                foreach(string db in serverDbs)
                {
                    Console.WriteLine($"\t{db}");
                }
            }
        }

        public void ShowServers()
        {
            Console.WriteLine("Servers:");
            foreach(string server in Servers.Keys)
            {
                Console.WriteLine($"\t{server}");
            }
        }
    }
}
