using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TickClock.Areas.Identity.Data;
using TickClock.Data;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace TickClock.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    //public class ApplicationUser : IdentityUser
    //{
    //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<TickClockUser> manager, string authenticationType)
    //{
    //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //    var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
    /// <summary>
    /// https://stackoverflow.com/questions/36528624/create-claims-identity-in-identity-3
    /// var userIdentity = new ClaimsIdentity(await manager.GetClaimsAsync(this), authenticationType);
    /// </summary>
    //    // Add custom user claims here
    //    return userIdentity;
    //}
    //}
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<TickClockUser, IdentityRole>
    {
        public AppClaimsPrincipalFactory(
            UserManager<TickClockUser> userManager
            , RoleManager<IdentityRole> roleManager
            , IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, roleManager, optionsAccessor)
        { }
    }

    //https://www.reflections-ibs.com/blog/articles/how-to-extend-asp-net-core-3-0-and-3-1-identity-user

    public class ApplicationDbContext : IDisposable
    {

        public static ApplicationDbContext Create()
        {
            var client = new MongoClient("mongodb+srv://tick-clock:Oreo_0505@cluster0.2fcrl.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var database = client.GetDatabase("Identity");
            var users = database.GetCollection<TickClockUser>("users");
            var roles = database.GetCollection<IdentityRole>("roles");
            return new ApplicationDbContext(users, roles);
        }

        private ApplicationDbContext(IMongoCollection<TickClockUser> users, IMongoCollection<IdentityRole> roles)
        {
            Users = users;
            Roles = roles;
        }

        public IMongoCollection<IdentityRole> Roles { get; set; }
        public IMongoCollection<TickClockUser> Users { get; set; }
        public void Dispose()
        {
        }
    }
}
