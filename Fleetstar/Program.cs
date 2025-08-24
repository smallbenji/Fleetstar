using Dapper;
using Fleetstar.Auth;
using Fleetstar.Components;
using Fleetstar.Helper;
using Fleetstar.Models;
using Microsoft.AspNetCore.Identity;
using Npgsql;

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
builder.Services.AddSingleton<EventRepository>();
builder.Services.AddSingleton<BookingRepository>();
builder.Services.AddTransient<DBHelper>();

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

await EnsureTablesCreated(app.Services.GetRequiredService<IConfiguration>());

app.Run();

async Task EnsureTablesCreated(IConfiguration config)
{
    using var db = new NpgsqlConnection(config.GetConnectionString("DefaultConnection"));

    var sql = @"
        CREATE TABLE IF NOT EXISTS events (
            id TEXT PRIMARY KEY,
            data JSONB NOT NULL
        );

        CREATE TABLE IF NOT EXISTS bookings (
            id TEXT PRIMARY KEY,
            data JSONB NOT NULL
        );
    ";

    await db.ExecuteAsync(sql);
}