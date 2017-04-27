using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Data.Models
{
    public enum SkillEnum { Programming, Design, ProblemSolving, Speaking, Medical, Other };
    public enum ExpertiseEnum : byte { None = 0x00, Novice = 0x01, Intermediate, Advanced, Expert };

    public abstract class Skill
    {
        protected Skill(SkillEnum @enum, byte expertise)
        {
            Type = @enum.ToString();
            Expertise = expertise;
        }

        public Skill()
        {
            Users = new SortedSet<User>();
        }

        private void SetExpertise(byte? value)
        {
            if (value != null && Enum.IsDefined(typeof(ExpertiseEnum), value))
                _expertise = (ExpertiseEnum)value;
        }

        private ExpertiseEnum _expertise = 0x00;
        public byte? Expertise { get { return _expertise != 0x00 ? (byte?)_expertise : 0x00; } set { SetExpertise(value); } }

        public string Description { get; set; }

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Key, Column(Order = 1)]
        public string Type { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
