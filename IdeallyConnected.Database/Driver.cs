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

    public class Driver
    {
        public static void Menu()
        {
            Console.WriteLine("\tA. Show available databases.");
            Console.WriteLine("\tB. Show available database servers.");
        }

        public static void Main(string[] args)
        {
            DatabaseManager dbManager = new DatabaseManager();
            //System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            //System.Configuration.ConfigurationSectionCollection sections = config.Sections;
            //Console.WriteLine(sections["appSettings"].ToString());
            SampleSuperstoreSection configSampleSuperstore = 
                (IdeallyConnected.TestDatabases.SampleSuperstoreSection)System.Configuration.ConfigurationManager.GetSection("TestDatabases/SampleSuperstore");
            
            Console.WriteLine((configSampleSuperstore.SectionInformation.ToString()));
            StreamReader fstream = File.OpenText(configSampleSuperstore.CsvFileName);
            if(fstream.Peek() > 0)
            {
                Console.WriteLine(fstream.Peek());
                fstream.Close();
            }
            Console.WriteLine("\t~~~ Database Manager ~~~\n");
            char menuSelection = 'm';
            bool programLoop = true;
            do
            {
                switch(menuSelection)
                {
                    case 'a': case 'A':
                        dbManager.ShowDatabases();
                        break;
                    case 'b': case 'B':
                        dbManager.ShowServers();
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
