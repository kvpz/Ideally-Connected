using System;
using System.Collections.Generic;
using System.Text;

namespace IdeallyConnected.Library
{
    public class UserMatch
    {
        public UserMatch()
        {

        }

        public int TotalMatches { get; set; }
        public List<string> Users { get; set; }

        public HashSet<string> FindMatches()
        {
            HashSet<string> repeatedUsers = new HashSet<string>();
            for(int i = 0; i < Users.Count; ++i)
            {
                for(int j = i+1; j < Users.Count; ++j)
                {
                    if(Users[i] == Users[j])
                    {
                        repeatedUsers.Add(Users[i]);
                    }
                }
            }

            return repeatedUsers;
        }


    }
}
