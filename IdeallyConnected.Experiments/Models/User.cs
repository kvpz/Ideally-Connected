using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Experiments.Models
{
    public class User
    {
        public User()
        {
            Skill = new HashSet<Skill>();
        }
        
        #region fields
        private int?             _locationIP;
        public string            locationName;
        #endregion

        #region properties
        [Key]
        [MaxLength(36)]
        public string                        Username { get; set; }
        // Foreign Key
        public virtual ICollection<Skill>    Skill    { get; set; }
        public int?                          locationsIP 
        {
            get { return _locationIP; }
            set { _locationIP = value == 0 ? null : value; }
        }
        #endregion
    }
}
