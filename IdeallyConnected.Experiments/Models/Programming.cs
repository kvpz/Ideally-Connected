using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Experiments.Models
{
    /*
        This becomes a dynamic proxy because all the properties in here are virtual.
    */
    public class Programming : Skill
    {
        private static char[] delimiters = { ' ', ',' };

        public Programming () : base(SkillEnum.Programming, 0x00)       
        {
            ProgrammingLanguages = new List<ProgrammingLanguage>();
        }

        public Programming(ExpertiseEnum expertise, string description, string languages) 
            : base(SkillEnum.Programming, (byte)expertise)
        {
            this.Description = description; 
            List<ProgrammingLanguage> plangs = languages.Split(delimiters).ToList().ConvertAll((a) => (ProgrammingLanguage)a);
            this.ProgrammingLanguages = new HashSet<ProgrammingLanguage>(plangs);

        }
        
        //public static implicit operator Programming(Programming p) => new Programming();
        public virtual ICollection<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    }
}
