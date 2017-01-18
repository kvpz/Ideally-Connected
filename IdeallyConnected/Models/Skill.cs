using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Models
{
    public class Skill
    {
        public String ProgrammingLanguages { get; set; }
        public int expertise { get; set; }
        public String 
    }

    /*
    public class Skills
    {
        [ForeignKey("UserProfile")]
        public string UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        [ForeignKey("ProgrammingLanguages")]
        public string ProgrammingLanguagesId { get; set; }
        public virtual ProgrammingLanguages ProgrammingLanguages { get; set; }
        public int expertise { get; set; }
    }
    */
}