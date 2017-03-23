using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Data.Models
{
    public partial class User 
    {
        public override string ToString()
        {
            return $"{this.UserName ?? "N/A"} {this.FirstName ?? "N/A"} {this.LastName ?? "N/A"}";
        }
    }
}
