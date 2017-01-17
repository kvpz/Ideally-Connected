using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Models
{
    public class ProgrammingLanguage
    {
    
    public class ProgrammingLanguages
    {
        [Key]
        public string ProgrammingLanguage { get; set; }
        public string type { get; set; } // functional, imperative, front-end, back-end, etc
    }
    }
}