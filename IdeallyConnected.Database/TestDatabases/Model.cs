using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases
{
    public abstract class Model<T> where T : class, new()
    {
        public delegate T InitializeModel(string[] attributes);

        public static InitializeModel TInitialize { get; set; }

        public Model()
        {
            TInitialize = delegate (string[] attributes) { return (T)Activator.CreateInstance(typeof(T), attributes); };
        }

        public void Add(string[] attributes)
        {

        }

        public static System.Reflection.PropertyInfo[] GetProperties()
        {
            return typeof(T).GetProperties();
        }
    }
}
