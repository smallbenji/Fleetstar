using Fleetstar.Auth;
using Fleetstar.Components;
using Fleetstar.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddUserStore<UserStore>()
    .AddRoleStore<RoleStore>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth";
});

builder.Services.AddSingleton<UserRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseAuthentication();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;


app.Run();
