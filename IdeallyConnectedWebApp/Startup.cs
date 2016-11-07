using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder; // BuilderExtensions.UseIdentity
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // IdentityRole, 
using Microsoft.EntityFrameworkCore;  // services.AddDbContext
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IdeallyConnectedWebApp.Data; // ApplicationDbContext
using IdeallyConnectedWebApp.Models;
using IdeallyConnectedWebApp.Services;

namespace IdeallyConnectedWebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
                
            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                //builder.AddUserSecrets();
            }

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Identity services are added here.
        public void ConfigureServices(IServiceCollection services)
        {
            //******************************************
            // Add framework services.
            
            services.AddDbContext<IdealConnectDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); // DefaultConnection in appsettings.json

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdealConnectDbContext>() //ApplicationDbContext>()
                .AddDefaultTokenProviders();
                /*
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            */           
            

            // Register services
            //var connection = @"Server=(localdb)\mssqllocaldb;Database=ideallyconnecteddb;Trusted_Connection=True;MultipleActiveResultSets=true";
            //services.AddDbContext<IdealConnectDbContext>(options => options.UseSqlServer(connection));
            // Add framework services
            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            //*******************************************/

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Cookie settings
                options.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                options.Cookies.ApplicationCookie.LogoutPath = "/Account/Logoff";

                // User settings
                options.User.RequireUniqueEmail = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IdealConnectDbContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();       // note
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();  // enables static file serving from the app.

            app.UseIdentity(); // Enable Identity; adds cookie-based authentication to the request pipeline.

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DbInitializer.Initialize(context);
        }
    }
}
