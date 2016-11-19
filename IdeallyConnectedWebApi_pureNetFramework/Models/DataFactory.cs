using System;
using System.Collections.Generic;
using System.Linq;

namespace IdeallyConnectedWebApi_pureNetFramework.Models
{
    public static class DataFactory
    {
        public static IEnumerable<ApplicationUser> GetUsers()
        {
            return new List<ApplicationUser>()
            {
                new ApplicationUser() { UserName = "suprlifter" },
                new ApplicationUser() { UserName = "diddlydo" }
            };
        }
    } // class DataFactory
}