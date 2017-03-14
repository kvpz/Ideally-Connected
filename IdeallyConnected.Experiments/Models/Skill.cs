using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Experiments.Models
{
    public abstract class Skill
    {
        private Skill(SkillEnum @enum)
        {
            //Console.WriteLine("~~~ IN SKILL CONSTRUCTOR 1 ~~~");
            ID = (int)@enum;
            Type = (int)@enum;
            _expertise = 0x00;
        }

        protected Skill(SkillEnum @enum, byte expertise) 
        { 
            //Console.WriteLine("~~~ IN SKILL CONSTRUCTOR 2 ~~~");
            ID = (int)@enum;
            Type = (int)@enum; 
            Expertise = expertise;
        }
        
        protected Skill() 
        {
            //Console.WriteLine("~~~ In SKILL PROTECTED CONSTRUCTOR ~~~");
            ID = 1;
        }

        private void SetExpertise(byte? value)
        {
            if(value != null && Enum.IsDefined(typeof(ExpertiseEnum), value))
                _expertise = (ExpertiseEnum)value;
        }

        private ExpertiseEnum    _expertise = 0x00;
        
        public int      ID          { get; set; } 
        public int      Type        { get; set; }
        public string   Description { get; set; }
        public byte?     Expertise   { get { return _expertise != 0x00 ? (byte?)_expertise : 0x00; } set { SetExpertise(value); } }
        public virtual User User { get; set; }
        //abstract public Func<SkillEnum, Skill> implicitConstructor { get; set; } // = (x) => new Skill(x);
        //public static implicit operator Skill(SkillEnum @enum);// => new Skill(@enum);
        public static implicit operator SkillEnum(Skill skill) => (SkillEnum)skill.ID;
    }
}
