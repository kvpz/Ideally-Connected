using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IdeallyConnected.Models
{
    public class ApplicationDataContextInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        
        private static ApplicationUser 
        NewApplicationUser(String UserName, String Biography, 
        Dictionary<String, SoftwareTypes> SoftwareDictionary, String Email)
        {
            return new ApplicationUser {
                UserName = UserName,
                Biography = Biography,
                Software = SoftwareDictionary
                            .Select( st => new Software() { Id = st.Key, Type = st.Value } ).ToList(),
                Email = "Uone@gewgle.com"
            };    
        }

        protected override void Seed(ApplicationDbContext context)
        {
            ApplicationUser user = NewApplicationUser("Uone",
                "I like programming and reading and guitar",
                new Dictionary<String, SoftwareTypes> () 
                { 
                    { "Visual Studio", SoftwareTypes.TextEditor },
                    { "OSX", SoftwareTypes.OperatingSystem },
                    { "Notepad++", SoftwareTypes.TextEditor }
                },
                "Utwo@gewgle.com");
            
        }
    }
}