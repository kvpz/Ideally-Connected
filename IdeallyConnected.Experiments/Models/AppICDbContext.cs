using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Experiments.Models
{
    public enum SkillEnum { Programming, Design, Speaking, Writing, Other };
    public enum ExpertiseEnum :byte { None = 0x00, Novice = 0x01, Intermediate, Advanced, Expert };

    // EF automatically creates 'IdeallyCo...ted.Exp...ts.AppICDbContext' database. No ConnectionString required.
    public class AppICDbContext : DbContext 
    {
        public DbSet<User>                  Users   { get; set; }
        public DbSet<Skill>                 Skills  { get; set; }    
        public DbSet<Programming>           Programmings  { get; set; }
        public DbSet<ProgrammingLanguage>   ProgrammingLanguages { get; set; }
    }
}
