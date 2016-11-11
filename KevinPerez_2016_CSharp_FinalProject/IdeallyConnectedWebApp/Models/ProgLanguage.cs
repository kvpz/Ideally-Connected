/*
    A programming language can be a skill to many users
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeallyConnectedWebApp.Models
{
    public enum LangType
    {
            lowlevel, midlevel, highlevel
    }

    public class ProgLanguage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ProgLanguageID { get; set; }
        public LangType? LangType { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}
