using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IdeallyConnectedWebApp.Data;

namespace IdeallyConnectedWebApp.Models
{
    public static class DbInitializer
    {
        public static void Initialize (IdealConnectDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any ApplicationUsers. If none, add data.
            if (context.Users.Any())
            {
                return; // DB has been seeded
            }

            var users = new ApplicationUser[]
            {
                
                new ApplicationUser {firstname="Kevin", lastname="Poroz", UserName="zwarted", Email="unknotted26@gmail.com", Skills = null },
                new ApplicationUser {firstname="Alex", lastname="Gimenez", UserName="bazinga2", Email="tester@testing.com" },
                new ApplicationUser {firstname="John", lastname="Paul", UserName="thepope2", Email="church@churching.com" },
                new ApplicationUser {firstname="Pedro", lastname="Gimenez", UserName="voteforpedro", Email="pedroboy@napoleanmovie.com"},
                new ApplicationUser {firstname="Kirsten", lastname="Granger", UserName="gloss123", Email="tatootie@hotmailz.com"} 
            };

            foreach(ApplicationUser _user in users)
            {
                context.Users.Add(_user);
            }
            context.SaveChanges();

            var proglangs = new ProgLanguage[]
            {
                new ProgLanguage {ProgLanguageID="C++", LangType = LangType.lowlevel},
                new ProgLanguage {ProgLanguageID="C", LangType=LangType.lowlevel},
                new ProgLanguage {ProgLanguageID="C#", LangType=LangType.midlevel},
                new ProgLanguage {ProgLanguageID="Ruby",LangType=LangType.highlevel},
                new ProgLanguage {ProgLanguageID="Python",LangType=LangType.highlevel},
                new ProgLanguage {ProgLanguageID="MIPS", LangType=LangType.lowlevel}
            };

            foreach(ProgLanguage _plang in proglangs)
            {
                context.ProgLanguages.Add(_plang);
            }
            context.SaveChanges();

            var software = new Software[]
            {
                new Software {SoftwareID="Visual Studio", Manufacturer="Microsoft"},
                new Software {SoftwareID="Tableau", Manufacturer="Tableau Software"},
                new Software {SoftwareID="QtCreator", Manufacturer="Qt Company"},
                new Software {SoftwareID="RubyMine", Manufacturer="JetBrains"},
                new Software {SoftwareID="Windows", Manufacturer="Microsoft"}
            };

            foreach(Software _software in software)
            {
                context.Softwares.Add(_software);
            }
            context.SaveChanges();
        }
    }
}
