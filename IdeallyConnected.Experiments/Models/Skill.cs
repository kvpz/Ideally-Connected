using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Experiments.Models
{
    public enum SkillEnum { Programming, Design, Speaking, Writing, Other };
    public enum ExpertiseEnum :byte { None = 0x00, Novice = 0x01, Intermediate, Advanced, Expert };

    public abstract class Skill
    {
        private Skill(SkillEnum @enum)
        {
            Console.WriteLine("~~~ IN SKILL CONSTRUCTOR 1 ~~~");
            //ID = (int)@enum;
            Type = (int)@enum;
            _expertise = 0x00;
        }

        protected Skill(SkillEnum @enum, byte expertise) 
        { 
            Console.WriteLine("~~~ IN SKILL CONSTRUCTOR 2 ~~~");
            //ID = (int)@enum;
            Type = (int)@enum; 
            Expertise = expertise;
        }
        
        protected Skill() 
        { }

        private void SetExpertise(byte? value)
        {
            if(value != null && Enum.IsDefined(typeof(ExpertiseEnum), value))
                _expertise = (ExpertiseEnum)value;
        }

        private ExpertiseEnum    _expertise = 0x00;
        //public int      ID          { get; set; } 

        public string   Description { get; set; }
        public byte?     Expertise   { get { return _expertise != 0x00 ? (byte?)_expertise : 0x00; } set { SetExpertise(value); } }
        [Key, Column(Order = 0)]
        public virtual User User { get; set; }
        [Key, Column(Order = 1)]
        public int      Type        { get; set; }
        public static implicit operator SkillEnum(Skill skill) => (SkillEnum)skill.Type; // skill.ID
        //abstract public Func<SkillEnum, Skill> implicitConstructor { get; set; } // = (x) => new Skill(x);
        //public static implicit operator Skill(SkillEnum @enum);// => new Skill(@enum);
    }
}
