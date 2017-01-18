using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Models
{
    /*
        1-1 relation with User; foreign key does not need to be specified.
        A unidirectional relationship is established by only defining the navigation property
        on only one of the types that participates in the relationship and not both.
    */
    public class UserProfile 
    {
        [Key, ForeignKey("User")] //("ApplicationUser")]
        public string UserId { get; set; }
        public string Biography { get; set; }
        public virtual User User { get; set; }

        public virtual List<ProgrammingLanguages> ProgrammingLanguages { get; set; }
        public virtual List<Software> Software { get; set; }
        /*
            Github account
            StackOverflow account
            Facebook Account
        */
    }
}