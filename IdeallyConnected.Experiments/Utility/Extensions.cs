using IdeallyConnected.Experiments.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Experiments.Utility
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
            //u.Skill.ToList().ForEach(printSkill);
        }

        public static void printDbSkills(this DbSet<Skill> dbskills)
        {
            foreach(Skill record in dbskills)
            {
                //record.printSkill();
            }
        }

        public static void printDbUsers(this DbSet<User> dbusers)
        {
            foreach(User record in dbusers)
            {
                record.printUser();
            }
        }

        public static void printSkill(this Programming pskill)
        {
            printSkill((Skill)pskill);
            List<ProgrammingLanguage> plist = pskill.ProgrammingLanguages.DefaultIfEmpty().ToList();
            foreach(ProgrammingLanguage plang in plist)
            {
                Console.Write($"{plang.language} ");
            }
        }
    }
}
