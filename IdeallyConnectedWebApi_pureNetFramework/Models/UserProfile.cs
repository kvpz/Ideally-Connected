using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Models
{
    public class UserProfile 
    {
        [Key, ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public string Biography { get; set; }
        public virtual User User { get; set; }
        
        /*
            Github account
            StackOverflow account
            Facebook Account
        */
    }
}