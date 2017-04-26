using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases
{
    public class LocationDb : DbManager
    {
        public Location _Location { get; set; }

        public LocationDb()
            : base("Locations")
        {
            _Location = new Location();
        }

        public void MainLoop()
        {
            Menu();
            string selection = "M";
            do
            {
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "a": case"A":

                        break;
                    case "b": case"B":

                        break;
                    case "m": case "M":
                        Menu();
                        break;
                    case "q": case "Q":
                        break;
                    default:
                        Menu();
                        break;
                }
            } while (selection != "q" && selection != "Q");
        }

        public override void Menu()
        {
            MiscUtility.WriteLineFormatted("Location Database Menu", ConsoleColor.DarkMagenta);
            Console.WriteLine("\tA. Load Locations from CSV");
            Console.WriteLine("\tB. Insert data into database");
            Console.WriteLine("\tQ. Go back");
            base.Menu();
        }
    }
}
