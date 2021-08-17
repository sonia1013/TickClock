//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Identity.Core;
//using TickClock.Data;

//namespace TickClock.Areas
//{
//    public class IdentityHostingStartup
//    {
//        // Add Identity for AspNetCore.Identity.Mongo, ApplicationRole is optional
//        services.AddIdentityMongoDbProvider<ApplicationUser, ApplicationRole>(identityOptions =>
//{
//    // Password settings.
//    IdentityOptions.Password.RequiredLength = 6;
//    IdentityOptions.Password.RequireLowercase = true;
//    IdentityOptions.Password.RequireUppercase = true;
//    IdentityOptions.Password.RequireNonAlphanumeric = false;
//    IdentityOptions.Password.RequireDigit = true;

//    // Lockout settings.
//    IdentityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
//    IdentityOptions.Lockout.MaxFailedAccessAttempts = 5;
//    IdentityOptions.Lockout.AllowedForNewUsers = true;

//    // User settings.
//    IdentityOptions.User.AllowedUserNameCharacters =
//      "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
//    IdentityOptions.User.RequireUniqueEmail = true;
//}, mongoIdentityOptions => {
//    mongoIdentityOptions.ConnectionString = "mongodb://localhost:27017/MyDB";
//    // mongoIdentityOptions.UsersCollection = "Custom User Collection Name, Default User";
//    // mongoIdentityOptions.RolesCollection = "Custom Role Collection Name, Default Role";
//}).AddDefaultUI(); //.AddDefaultUI() to temporary remove error when no EmailSender provided, see https://stackoverflow.com/questions/52089864/

//// This is required to ensure server can identify user after login
//services.ConfigureApplicationCookie(options =>
//{
//    // Cookie settings
//    options.Cookie.HttpOnly = true;
//    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

//    options.LoginPath = "/Identity/Account/Login";
//    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
//    options.SlidingExpiration = true;
//});

