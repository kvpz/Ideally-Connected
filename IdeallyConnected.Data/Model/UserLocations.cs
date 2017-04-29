using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Data.Models
{
    [Table("UserLocations")]
    public class UserLocations
    {
        [Key, Column(Order = 0)]
        public virtual string UserID { get; set; }

        [Key, Column(Order = 1)]
        public virtual int LocationID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("LocationID")]
        public virtual Location Location { get; set; }

        public int TotalVisitations { get; set; }
        public DateTime FirstVisited { get; set; }
        public DateTime LastVisited { get; set; }
    }
}
