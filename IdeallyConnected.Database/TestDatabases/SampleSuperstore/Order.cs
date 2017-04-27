using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases
{
    public class Order : Model<Order>
    {
        public Order()
        { }

        /// <summary>
        /// Constructor method used to initialize the properties with string values
        /// converted to the appropriate type.
        /// </summary>
        /// <param name="attributeData"></param>
        public Order(params string[] attributeData)
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
            for(int i = 0; i < properties.Count(); ++i)
            {
                if (properties[i].PropertyType == typeof(string))
                    properties[i].SetValue(this, attributeData[i]);
                else if (properties[i].PropertyType == typeof(int))
                    properties[i].SetValue(this, Int32.Parse(attributeData[i]));
                else if (properties[i].PropertyType == typeof(float))
                    properties[i].SetValue(this, float.Parse(attributeData[i]));
                else if (properties[i].PropertyType == typeof(DateTime))
                    properties[i].SetValue(this, DateTime.Parse(attributeData[i]));
            }
        }

        public string OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string ShipMode { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Segment { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
        public string ProductID { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ProductName { get; set; }
        public float Sales { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public float Profit { get; set; }
    }
}
