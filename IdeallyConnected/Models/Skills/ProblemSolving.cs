using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Models
{
    [Table("ProblemSolvingSkills")]
    public class ProblemSolving : Skill
    {
        public ProblemSolving() : base(SkillEnum.ProblemSolving, 0x00) {}

        public string Tools { get; set; }
    }
}