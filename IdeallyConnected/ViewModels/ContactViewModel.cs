using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}