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
            Console.WriteLine($"\nUsername: {u.username} \nlocationName: {u.locationName} \nlocationsIP: {u.locationsIP}");
            u.Skill.printSkill(); 
        }

        public static void printDbSkills(this DbSet<Skill> dbskills)
        {
            foreach(var record in dbskills)
            {
                record.printSkill();
            }
        }

        public static void printDbUsers(this DbSet<User> dbusers)
        {
            foreach(var record in dbusers)
            {
                record.printUser();
            }
        }
    }



    // EF automatically creates 'IdeallyCo...ted.Exp...ts.AppICDbContext' database. No ConnectionString required.
    public class AppICDbContext : DbContext 
    {
        public DbSet<User>  Users   { get; set; }
        public DbSet<Skill> Skills  { get; set; }    
    }

    public class User
    {
        #region fields
        private bool             _visitor = true;
        private int?             _locationIP;
        // Name of the physical hosting location (use proximity beacon)
        public string           locationName;
        #endregion
        #region properties
        [Key]
        public string           username { get; set; }
        // Foreign Key
        public virtual Skill    Skill    { get; set; }

        // The IP address of the nearby beacons. 
        public int?             locationsIP 
                                { 
                                    get { return _locationIP; } 
                                    set { _locationIP = value == 0 ? null : value; } 
                                }
        #endregion
    }

    public enum SkillEnum { Programming, Design, Speaking, Writing, Other };

    public class Skill
    {
        // Called implicitly when assigning a skill object with a SkillEnum.
        private Skill(SkillEnum @enum)
        {
            ID = (int)@enum;
            Type = (int)@enum;
            Description = @enum.GetEnumDescription();
        }

        protected Skill() { }

        public int      ID          { get; set; } 
        public int      Type        { get; set; }
        public string   Description { get; set; }
        public static implicit operator Skill(SkillEnum @enum) => new Skill(@enum);
        public static implicit operator SkillEnum(Skill skill) => (SkillEnum)skill.ID;
    }
}
