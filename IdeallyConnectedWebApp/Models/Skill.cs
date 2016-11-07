/*
    Entity framework interprets a property as a foreign key property if it's named 
    <navigation property name> <primary key property name> (ex. StudentID for Student) OR
    just <primary key property name>

    The Skill entity set should be considered a weak entity set because it does not have a 
    primary key of its own; and it would be meaningless.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallyConnectedWebApp.Models
{
    public enum Experience
    {
        Beginner, Intermediate, Expert
    }

    public class Skill
    {
        //public int ID { get; set; }
        // public int ID { get; set; }
        public int SkillID { get; set; }  
        public Experience? Experience { get; set; } // nullable

        public ApplicationUser ApplicationUser { get; set; } 
        public ProgLanguage ProgLang { get; set; }
        public Software Software { get; set; }
    }
}
