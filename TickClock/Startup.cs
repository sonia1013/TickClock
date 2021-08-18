using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using AspNetCore.Identity.MongoDbCore.Models;
using AspNetCore.Identity.MongoDbCore;
using MongoDB.Bson.Serialization;
using TickClock.Models;
using TickClock.Services;
using AspNetCore.Identity.Mongo.Model;
using AspNetCore.Identity.Mongo;
using Microsoft.AspNetCore.Authorization;
using TickClock.Areas.Identity.Data;

namespace TickClock
{
    public class Startup
    {
        private string ConnectionString => Configuration.GetConnectionString("ConnectionString");

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TickClockDatabaseSettings>(
                Configuration.GetSection(nameof(TickClockDatabaseSettings)));

            services.AddSingleton<ITickClockDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<TickClockDatabaseSettings>>().Value);

            // At the ConfigureServices section in Startup.cs
            //services.AddIdentityMongoDbProvider<MongoUser>();

            //services.AddIdentityMongoDbProvider<TickClockUser>(identity =>
            //{
            //    identity.Password.RequireDigit = false;
            //    identity.Password.RequireLowercase = false;
            //    identity.Password.RequireNonAlphanumeric = false;
            //    identity.Password.RequireUppercase = false;
            //    identity.Password.RequiredLength = 1;
            //    identity.Password.RequiredUniqueChars = 0;
            //},
            //    mongo =>
            //    {
            //        mongo.ConnectionString = ConnectionString;
            //    }
            //);

            services.AddSingleton<ClockService>();

            services.AddControllers();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
