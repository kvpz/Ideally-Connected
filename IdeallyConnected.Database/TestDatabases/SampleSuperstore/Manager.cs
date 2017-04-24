using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases
{

    public abstract class IModel<T> where T : class, new()
    {
        private T _model { get; set; }
        public static InitializeModel TInitialize { get; set; }

        public IModel(params string[] args)
        {
            TInitialize = delegate (string[] attributes) { return (T)Activator.CreateInstance(typeof(T), attributes); };//return attributes; };
        }

        public void Add(string[] attributes)
        {

        }

        public delegate T InitializeModel(string[] attributes);
    }

    public class Manager : IModel<Manager>
    {
        public string Person { get; set; }
        public string Region { get; set; }

        public Manager()
        { }

        public Manager(params string[] attributes)
        {
            Person = attributes[0];
            Region = attributes[1];
        }
        
        public static implicit operator Manager(string[] attributes)
        {
            return new Manager(attributes);
        }
    }
}
