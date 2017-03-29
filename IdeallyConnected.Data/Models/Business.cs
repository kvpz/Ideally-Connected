using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Data.Models
{
    public class Business
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public bool? ChatService { get; set; }
        public bool? P2PService { get; set; }
        public bool? IdentificationService { get; set; }
    }
}