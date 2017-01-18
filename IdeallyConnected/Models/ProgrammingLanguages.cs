using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Models
{    
    /*
        There are not many Programming Languages so I think a string id is most appropriate.
    */
    public class ProgrammingLanguages
    {
        [Key]
        public String Id { get; set; }

    }
}