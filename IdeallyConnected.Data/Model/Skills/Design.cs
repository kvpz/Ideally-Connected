using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Data.Models
{
    [Table("DesignSkills")]
    public class Design : Skill
    {
        public Design() : base(SkillEnum.Design, 0x00) {}

        public string TypeOfDesign { get; set; }
        public string Software { get; set; }
    }
}