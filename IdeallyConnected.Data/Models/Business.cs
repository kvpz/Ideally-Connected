using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Models
{
    public class Business
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int LocationID { get; set; }
        public bool? ChatService { get; set; }
        public bool? P2PService { get; set; }
        public bool? IdentificationService { get; set; }
    }
}