using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Data.Models
{
    public partial class User : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            bool result = x.UserName == y.UserName && x.FirstName == y.FirstName && x.LastName == y.LastName
                          && x.Email == y.Email;
            return result;
        }

        public int GetHashCode(User obj)
        {
            return obj.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.UserName ?? "N/A"} {this.FirstName ?? "N/A"} {this.LastName ?? "N/A"}";
        }
    }
}
