using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Models
{
    [Table("ProgrammingSkills")]
    public class Programming : Skill
    {
        private static char[] delimiters = { ' ', ',' };

        public Programming () : base(SkillEnum.Programming, 0x00)       
        { }

        public Programming(ExpertiseEnum expertise, string description, string languages, string software) 
            : base(SkillEnum.Programming, (byte)expertise)
        {
            this.Description = description; 
            ProgrammingLanguages = languages;
            Software = software;
        }
        
        public string ProgrammingLanguages { get; set; }
        public string Software { get; set; }        
    }

}