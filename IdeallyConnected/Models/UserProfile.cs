using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Models
{
    /*
        1-1 relation with User; foreign key does not need to be specified.
        A unidirectional relationship is established by only defining the navigation property
        on only one of the types that participates in the relationship and not both.
    */
    public partial class ApplicationUser//UserProfile 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        
        protected virtual ICollection<Skill> _skillSet { get; set; }

        public class UserMapper : EntityTypeConfiguration<ApplicationUser>
        {
            public UserMapper()
            {
                HasMany(s => s._skillSet);
            }
        }

    }
}