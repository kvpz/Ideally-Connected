using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Data.Models
{
    public class Business
    {
        //[Key, Column(Order = 0)]
        //public int ID { get; set; }

        [Key, Column(Order = 0)]
        public string Name { get; set; }

        [Key, Column(Order = 1)]
        public virtual Guid LocationID { get; set; }

        [ForeignKey("Location")]
        public virtual Location Location { get; set; }

        public bool ChatService { get; set; }
        public bool P2PService { get; set; }
    }
}