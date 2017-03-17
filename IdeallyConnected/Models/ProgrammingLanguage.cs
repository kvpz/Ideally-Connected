using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Models
{
    public class ProgrammingLanguage : IComparable<ProgrammingLanguage>
    {
        public static implicit operator ProgrammingLanguage(string language) => new ProgrammingLanguage(language); 

        public ProgrammingLanguage() {} 

        private ProgrammingLanguage(string language)
        {
            //Console.WriteLine("**** IN PROGRAMMINGLANGUAGE private Constructor ****");
            this.language = language;
        }
                
        //[Key, Column(Order = 0)]
        //public int Id { get; set; }
        //[Key, Column(Order = 1)]
        [MaxLength(12)]
        [Key, Column(Order = 0)]
        public string language { get; set; }

        //[Key, Column(Order = 1)]
        //public string UserId { get; set; }

        //[ForeignKey("UserId")]
        //public virtual ApplicationUser SubSkillUser { get; set; }
        
        //public virtual ICollection<Programming> Programming { get; set; }

        public int CompareTo(ProgrammingLanguage obj)
        {
            if(obj == null)
                throw new NotImplementedException();
            //Console.WriteLine($"Language CompareTO(): { this.language } vs { obj.language }");
            if(this.language == obj.language)
                return 0;
            else
                return 1;
        }
    }
}