using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases
{
    public class DbUtility
    {
    }

    public static class MiscUtility
    {
        public static void WriteLineFormatted(string str, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(str);
            Console.ResetColor();
        }
    }
}
