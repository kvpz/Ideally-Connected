using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases
{
    public class Return : Model<Return>
    {
        public string OrderID { get; set; }
        public bool Returned { get; set; }

        public Return()
        { }

        /// <summary>
        /// Constructor method used to initialize the properties with string values
        /// converted to the appropriate type.
        /// </summary>
        /// <param name="attributeData"></param>
        public Return(params string[] attributeData)
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
            for (int i = 0; i < properties.Count(); ++i)
            {
                if (properties[i].PropertyType == typeof(string))
                    properties[i].SetValue(this, attributeData[i]);
                else if (properties[i].PropertyType == typeof(bool))
                {
                    if (attributeData[i].ToLower() == "yes")
                        properties[i].SetValue(this, true);
                    else
                        properties[i].SetValue(this, false);
                }
            }
        }
    }
}
