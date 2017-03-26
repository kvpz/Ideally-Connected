using System;
using System.Collections.Generic;

namespace IdeallyConnected.Library
{
    public class Analysis
    {
        public Analysis()
        {
            Created = DateTime.Now;
            Variables = null;
        }

        public Analysis(params string[] variables)
        {
            Created = DateTime.Now;
            Variables = new List<string>(variables);
        }

        public bool Run(bool pass = false)
        {
            Completed = DateTime.Now;
            return pass;
        }

        public string Type { get; set; }
        public DateTime Created { get; set; }
        public DateTime Completed { get; set; }
        public List<string> Variables { get; set; }
    }
}
