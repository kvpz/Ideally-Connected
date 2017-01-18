using System;
using System.Collections.Generic;
using System.Linq;

namespace IdeallyConnected.Models
{
    public static class DataFactory
    {
        public static IEnumerable<ApplicationUser> GetUsers()
        {
            return new List<ApplicationUser>()
            {
                new ApplicationUser() { UserName = "suprlifter", Email = "abc@abc.com" },
                new ApplicationUser() { UserName = "diddlydo", Email = "bcda@bcda.com" },
                new ApplicationUser() { UserName = "blaboob", Email = "youthere@abc.com" }
            };
        }
    } // class DataFactory
}