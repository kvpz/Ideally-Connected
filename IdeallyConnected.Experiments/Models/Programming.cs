using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Experiments.Models
{
    public class Programming : Skill
    {
        private static char[] delimiters = { ' ', ',' };

        public Programming () : base(SkillEnum.Programming, 0x00)       
        {
            ProgrammingLanguages = new HashSet<ProgrammingLanguage>();
        }

        public Programming(ExpertiseEnum expertise, string description, string languages) 
            : base(SkillEnum.Programming, (byte)expertise)
        {
            this.Description = description; 
            this.ProgrammingLanguages = new HashSet<ProgrammingLanguage>();
        }

        //public static implicit operator Programming(Programming p) => new Programming();
        // This should not be initialized in here.
        public virtual ISet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    }
}
