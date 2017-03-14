using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.Entity.Migrations;

namespace IdeallyConnected.Experiments
{
    public static class Extensions
    {
        public static string GetEnumDescription<TEnum>(this TEnum item)
            => item.GetType()
                .GetField(item.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault()?.Description ?? string.Empty;
        
        /// <summary>
        /// Writes Enumeration's values to database context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="converter"> Lambda function that converts an enum type to a value of another type. </param>
        public static void SeedEnumValues<T,TEnum>(this IDbSet<T> dbSet, Func<TEnum, T> converter) where T : class
            => Enum.GetValues(typeof(TEnum))
                .Cast<object>()
                .Select(value => converter((TEnum)value))
                .ToList()
                .ForEach(instance => dbSet.AddOrUpdate(instance));

        public static void printSkill(this Skill s)
        {
            Console.WriteLine($"Skills\nID: {s.ID} \nDescription: {s.Description} \nType: {(SkillEnum)s.Type}\n");
        }

        public static void printUser(this User u)
        {
            Console.WriteLine($"\nUsername: {u.Id} \nlocationName: {u.locationName} \nlocationsIP: {u.locationsIP}");
            u.Skill.ToList().ForEach(printSkill);
        }

        public static void printDbSkills(this DbSet<Skill> dbskills)
        {
            foreach(Skill record in dbskills)
            {
                record.printSkill();
            }
        }

        public static void printDbUsers(this DbSet<User> dbusers)
        {
            foreach(User record in dbusers)
            {
                record.printUser();
            }
        }
    }



    // EF automatically creates 'IdeallyCo...ted.Exp...ts.AppICDbContext' database. No ConnectionString required.
    public class AppICDbContext : DbContext 
    {
        public DbSet<User>                  Users   { get; set; }
        public DbSet<Skill>                 Skills  { get; set; }    
        public DbSet<Programming>           Programmings  { get; set; }
        public DbSet<ProgrammingLanguage>   ProgrammingLanguages { get; set; }

    }

    public class User
    {
        #region fields
        private int?             _locationIP;
        public string            locationName;
        #endregion
        #region properties
        [Key]
        [MaxLength(36)]
        public string                        Id { get; set; }
        // Foreign Key
        public virtual ICollection<Skill>    Skill    { get; set; }
        public int?                          locationsIP 
        {
            get { return _locationIP; }
            set { _locationIP = value == 0 ? null : value; }
        }
        #endregion
    }

    public enum SkillEnum { Programming, Design, Speaking, Writing, Other };
    public enum ExpertiseEnum :byte { None = 0x00, Novice = 0x01, Intermediate, Advanced, Expert };

    public class Programming : Skill
    {
        private static char[] delimiters = { ' ', ',' };

        public Programming () : base(SkillEnum.Programming, 0x00)       
        {
            ProgrammingLanguages = new HashSet<ProgrammingLanguage>();
        }

        public Programming(ExpertiseEnum expertise, string description, string languages) 
            : base(SkillEnum.Programming, (byte)expertise)
        {
            this.Description = description; 
            this.ProgrammingLanguages = new HashSet<ProgrammingLanguage>();
        }

        //public static implicit operator Programming(Programming p) => new Programming();
        // This should not be initialized in here.
        public virtual ISet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    }

    public class ProgrammingLanguage : IComparable<ProgrammingLanguage>
    {
        public ProgrammingLanguage() {} 

        private ProgrammingLanguage(string language)
        {
            //Console.WriteLine("**** IN PROGRAMMINGLANGUAGE private Constructor ****");
            this.language = language;
        }
        
        public static implicit operator ProgrammingLanguage(string language) => new ProgrammingLanguage(language); 
        
        [Key]
        [MaxLength(12)]
        public string language { get; set; }

        public int CompareTo(ProgrammingLanguage obj)
        {
            if(obj == null)
                throw new NotImplementedException();
            //Console.WriteLine($"Language CompareTO(): { this.language } vs { obj.language }");
            if(this.language == obj.language)
                return 0;
            else
                return 1;
        }
    }

    /*
    public class Design : Skill
    {
        public Design() : base(SkillEnum.Design)
        {

        }
    }

    public class MiscellaneousSkill : Skill
    {
        public MiscellaneousSkill() : base() {}
    }
    */

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
