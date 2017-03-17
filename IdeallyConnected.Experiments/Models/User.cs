using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Experiments.Models
{
    public class User
    {
        public User()
        {
            //Skill = new HashSet<Skill>();
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
        protected virtual ICollection<Skill>    Skill    { get; set; }
        public int?                          locationsIP 
        {
            get { return _locationIP; }
            set { _locationIP = value == 0 ? null : value; }
        }
        #endregion

        //protected virtual ICollection<Skill> _skillSet { get; set; }
        public class UserMapper : EntityTypeConfiguration<User>
        {
            public UserMapper()
            {
                HasMany(u => u.Skill);
            }
        }
    }
}
