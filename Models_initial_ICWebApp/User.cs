using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallyConnectedWebApp.Models
{
    public class User
    {
        public int ID { get; set; }  // EF interprets properties named *ID as the primary key
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }

        // One User instance can have many Skills
        // EF creates a HashSet by default if this property is used.
        public ICollection<Skill> Skill { get; set; } // considered a "navigation property"
    }
}
