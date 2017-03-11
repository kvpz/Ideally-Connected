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
        
        public static void SeedEnumValues<T,TEnum>(this IDbSet<T> dbSet, Func<TEnum, T> converter) where T : class
            => Enum.GetValues(typeof(TEnum))
                .Cast<object>()
                .Select(value => converter((TEnum)value))
                .ToList()
                .ForEach(instance => dbSet.AddOrUpdate(instance));

    }

    // EF automatically creates 'IdeallyCo...ted.Exp...ts.AppICDbContext' database. No ConnectionString required.
    public class AppICDbContext : DbContext 
    {
        public DbSet<User>  Users   { get; set; }
        public DbSet<Skill> Skills  { get; set; }    
    }

    public class User
    {
        [Key]
        public string           username { get; set; }
        // Foreign Key
        public virtual Skill    Skill    { get; set; }
        // Are they visitors to the website or registered users?
        private bool            visitor;
        // The IP address of the nearby beacons. 
        public int              locationsIP;
        // Name of the physical hosting location (use proximity beacon)
        public string           locationName;
        //public Skill skills;
        
    }

    public enum SkillEnum { Programming, Design, Speaking, Writing, Other };

    public class Skill
    {
        private Skill(SkillEnum @enum)
        {
            ID = (int)@enum;
            Description = @enum.GetEnumDescription();
            Console.WriteLine("In Skill private constructor");
        }

        protected Skill() { }

        public int ID { get; set; }
        public string Description { get; set; }
        public static implicit operator Skill(SkillEnum @enum) => new Skill(@enum);
        public static implicit operator SkillEnum(Skill skill) => (SkillEnum)skill.ID;
    }
}
