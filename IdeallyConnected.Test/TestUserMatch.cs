using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Test
{
    public class TestUserMatch
    {
        [CheckThisMethod]
        public void ReturnRepeatedUsers()
        {
            List<string> users = new List<string>() { "Bob", "Bob", "John", "Chris", "Billy", "John", "Bill", "Steve", "Bill", "Jimmy" };
            var usermatcher = new Library.UserMatch();
            
            usermatcher.Users = new List<string>(users);
            HashSet<string> uniqueUserSet = new HashSet<string>(users, StringComparer.Ordinal);
            for(int i = users.Count-1; uniqueUserSet.Count > 0 && i > 0; --i)
            {
                if(uniqueUserSet.Contains(users[i]))
                {
                    uniqueUserSet.Remove(users[i]);
                    users.RemoveAt(i);
                }
            }
  
            var result = usermatcher.FindMatches();
            HashSet<string> resultChecker = new HashSet<string>(users, StringComparer.Ordinal);
            string sa = resultChecker.Count.ToString(), sb = result.Count.ToString();
            MyAssert.AreEqual(resultChecker, result, $"Repeated users were not caught.  { sa } - { sb }");
        }
    }
}
