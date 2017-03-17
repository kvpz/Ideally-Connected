using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Models
{
    public class Design : Skill
    {
        public Design() : base(SkillEnum.Design, 0x00) {}
        public string DesignSubSkill { get; set; }        
    }
}