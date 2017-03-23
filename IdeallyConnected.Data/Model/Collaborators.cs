using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Data.Models
{
    public class Collaborators
    {
        [Key, Column(Order = 0)]
        public virtual string UserA { get; set; }

        [Key, Column(Order = 1)]
        public virtual string UserB { get; set; }

        [ForeignKey("UserA")]
        public virtual User ApplicationUser1 { get; set; }

        [ForeignKey("UserB")]
        public virtual User ApplicationUser2 { get; set; }

        // Total amount of times both users collaborated with each other
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public uint TotalCollaborations { get; set; }

        // True if UserA is following UserB
        public bool Following { get; set; }

        // True if UserA initiated the contact
        public bool Initiated { get; set; } 
        
        // Initial collaboration
        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime InitialCollaboration { get; set; }
    }
}