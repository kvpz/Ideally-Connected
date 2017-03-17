using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Models
{
    public class Programming : Skill
    {
        private static char[] delimiters = { ' ', ',' };

        public Programming () : base(SkillEnum.Programming, 0x00)       
        {
            //ProgrammingLanguages = new HashSet<ProgrammingLanguage>();
            ProgrammingLanguages = null;
        }

        public Programming(ExpertiseEnum expertise, string description, string languages) 
            : base(SkillEnum.Programming, (byte)expertise)
        {
            this.Description = description; 
            //List<ProgrammingLanguage> plangs = languages.Split(delimiters).ToList().ConvertAll((a) => (ProgrammingLanguage)a);
            //this.ProgrammingLanguages = new HashSet<ProgrammingLanguage>(plangs);

        }
        
        //public static implicit operator Programming(Programming p) => new Programming();
        public virtual ICollection<ProgrammingLanguage> ProgrammingLanguages { get; set; }

    }
}