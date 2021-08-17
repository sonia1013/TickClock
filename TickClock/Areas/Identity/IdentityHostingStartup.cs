using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TickClock.Areas.Identity.Data;
using TickClock.Data;

[assembly: HostingStartup(typeof(TickClock.Areas.Identity.IdentityHostingStartup))]
namespace TickClock.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityContextConnection")));

                services.AddDefaultIdentity<TickClockUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityContext>();

                services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

                services.AddIdentityCore<TickClockUser>()
                        .AddRoles<IdentityRole>()
                        .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<IdentityContext, IdentityRole>>()
                        .AddEntityFrameworkStores<IdentityContext>()
                        .AddDefaultTokenProviders()
                        .AddDefaultUI();

            });
        }
    }
}