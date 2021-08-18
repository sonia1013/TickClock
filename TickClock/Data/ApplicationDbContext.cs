using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.AspNetCore.Identity.MongoDB;
using Microsoft.AspNetCore.Identity;
using AspNetCore.Identity.MongoDbCore.Models;

namespace TickClock.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : MongoIdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            //var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            var userIdentity = new ClaimsIdentity(await manager.GetClaimsAsync(this), authenticationType);
            // https://stackoverflow.com/questions/36528624/create-claims-identity-in-identity-3
            // Add custom user claims here
            return userIdentity;
        }
    }
    //public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<TickClockUser, IdentityRole>
    //{
    //    public AppClaimsPrincipalFactory(
    //        UserManager<TickClockUser> userManager
    //        , RoleManager<IdentityRole> roleManager
    //        , IOptions<IdentityOptions> optionsAccessor)
    //    : base(userManager, roleManager, optionsAccessor)
    //    { }
    //}

    //https://www.reflections-ibs.com/blog/articles/how-to-extend-asp-net-core-3-0-and-3-1-identity-user

    public class ApplicationDbContext : IDisposable
    {

        public static ApplicationDbContext Create()
        {
            var client = new MongoClient("mongodb+srv://tick-clock:Oreo_0505@cluster0.2fcrl.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var database = client.GetDatabase("Identity");
            var users = database.GetCollection<MongoIdentityUser>("users");
            var roles = database.GetCollection<MongoIdentityRole>("roles");
            return new ApplicationDbContext(users, roles);
        }

        private ApplicationDbContext(IMongoCollection<MongoIdentityUser> users, IMongoCollection<MongoIdentityRole> roles)
        {
            Users = users;
            Roles = roles;
        }

        public IMongoCollection<MongoIdentityRole> Roles { get; set; }
        public IMongoCollection<MongoIdentityUser> Users { get; set; }
        public void Dispose()
        {
        }
    }
}
