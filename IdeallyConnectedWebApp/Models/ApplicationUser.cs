using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdeallyConnectedWebApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        
        // One User instance can have many Skills
        // EF creates a HashSet by default if this property is used.
        public ICollection<Skill> Skills { get; set; } // considered a "navigation property"
    }
}
