using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace IdeallyConnected.Library.Tests.NaiveBayes
{
    public class Cancer
    {
        public Dictionary<string, string> Attribute { get; set; }
    }

    /*
        Stores attributes as hard-coded properties, or efficiently via
        the inherited Cancer class.
    */
    public class BreastCancer : Cancer, IModel
    {
        public BreastCancer() { }

        public BreastCancer(string data)
        {
            this.Attribute = new Dictionary<string, string>();
            string[] attributes = data.Split(' ');
            ClassLabel = attributes[0];
            for(int i = 1; i < attributes.Length; ++i)
            {
                string[] attributeAndData = attributes[i].Split(':');
                this[attributeAndData[0]] = attributeAndData[1];
                this.Attribute[attributeAndData[0]] = attributeAndData[1];
            }
        }

        public object this[string attribute]
        {
            get
            {
                PropertyInfo attr = typeof(BreastCancer).GetRuntimeProperty("A" + attribute);
                return attr.GetValue(this, null);
            }
            set
            {
                PropertyInfo attr = typeof(BreastCancer).GetRuntimeProperty("A" + attribute);
                attr.SetValue(this, value);
            }
        }

        public string ClassLabel { get; set; }

        #region class attributes
        public string A1 { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }
        public string A4 { get; set; }
        public string A5 { get; set; }
        public string A6 { get; set; }
        public string A7 { get; set; }
        public string A8 { get; set; }
        public string A9 { get; set; }
        #endregion

        public object Create(string datafile)
        {
            return new BreastCancer(datafile);
        }
    }
}
