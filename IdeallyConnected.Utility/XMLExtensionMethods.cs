using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace IdeallyConnected.Utility.Components
{
    public static class XMLExtensionMethods
    {
        public static T GetAs<T>(this XElement element, T defaultValue = default(T))
        {
            T value = defaultValue;
            
            if(element != null && !string.IsNullOrEmpty(element.Value))
            {
                value = (T)Convert.ChangeType(element.Value, typeof(T));
            }

            return value;
        }
    }
}