using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Data.Models
{
    [Table("MedicalSkills")]
    public class Medical : Skill
    {
        public Medical() : base(SkillEnum.Medical, 0x00) 
        {
            CPR = false;
            EKG = false;
            Transfussions = false;
        }

        public bool CPR { get; set; }
        public bool EKG { get; set; }
        public bool Transfussions { get; set; }
    }
}