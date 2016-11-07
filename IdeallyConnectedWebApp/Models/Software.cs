using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeallyConnectedWebApp.Models
{
    public class Software
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SoftwareID { get; set; }
        public string Manufacturer { get; set; }

        public ICollection<Skill> Skills { get; set; }
    }
}
