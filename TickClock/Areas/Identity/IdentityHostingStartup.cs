using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TickClock.Areas.Identity.Data;
using TickClock.Data;
using MongoDB;
using MongoDB.Driver;
using Microsoft.CodeAnalysis;
using AspNetCore.Identity.Mongo;
using AspNetCore.Identity.Mongo.Model;

[assembly: HostingStartup(typeof(TickClock.Areas.Identity.IdentityHostingStartup))]
namespace TickClock.Areas.Identity
{
    //public class ApplicationUser : MongoUser
    //{
    //}

    //public class ApplicationRole : MongoRole
    //{
    //}


    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
               

                // Add Identity for AspNetCore.Identity.Mongo, ApplicationRole is optional
                services.AddIdentityMongoDbProvider<MongoUser,MongoRole>(identityOptions =>
                    {
                        // Password settings.
                        identityOptions.Password.RequiredLength = 6;
                        identityOptions.Password.RequireLowercase = true;
                        identityOptions.Password.RequireUppercase = true;
                        identityOptions.Password.RequireNonAlphanumeric = false;
                        identityOptions.Password.RequireDigit = true;

                        // Lockout settings.
                        identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                        identityOptions.Lockout.MaxFailedAccessAttempts = 5;
                        identityOptions.Lockout.AllowedForNewUsers = true;

                        // User settings.
                        //identityOptions.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                        //identityOptions.User.RequireUniqueEmail = true;
                    }, 
                    mongoIdentityOptions => 
                    {
                        mongoIdentityOptions.ConnectionString = "mongodb+srv://tick-clock:Oreo_0505@cluster0.2fcrl.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
                        mongoIdentityOptions.UsersCollection = "ApplicationUser";
                        mongoIdentityOptions.RolesCollection = "clientRole";
                    }).AddDefaultUI(); 
                    //.AddDefaultUI() to temporary remove error when no EmailSender provided, see https://stackoverflow.com/questions/52089864/

                // This is required to ensure server can identify user after login
                services.ConfigureApplicationCookie(options =>
                {
                    // Cookie settings
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                    options.LoginPath = "/Identity/Pages/Account/Login";
                    options.AccessDeniedPath = "/Identity/Pages/Account/AccessDenied";
                    options.SlidingExpiration = true;
                });
            });
        }
    }
}