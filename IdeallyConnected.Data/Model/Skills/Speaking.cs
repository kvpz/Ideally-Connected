using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Data.Models
{
    [Table("SpeakingSkills")]
    public class Speaking : Skill
    {
        public Speaking() : base(SkillEnum.Speaking, 0x00) {}

        public string Languages { get; set; }
    }
}