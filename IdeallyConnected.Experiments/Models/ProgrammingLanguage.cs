using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Experiments.Models
{
    public class ProgrammingLanguage : IComparable<ProgrammingLanguage>
    {
        public ProgrammingLanguage() {} 

        private ProgrammingLanguage(string language)
        {
            //Console.WriteLine("**** IN PROGRAMMINGLANGUAGE private Constructor ****");
            this.language = language;
        }
        
        public static implicit operator ProgrammingLanguage(string language) => new ProgrammingLanguage(language); 
        
        [Key]
        [MaxLength(12)]
        public string language { get; set; }

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
