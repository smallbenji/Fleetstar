using Dapper;
using Fleetstar.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Fleetstar.Components
{
    public class UserRepository : Controller
    {
        private readonly IConfiguration config;

        private NpgsqlConnection Connection => new NpgsqlConnection(config.GetConnectionString("Defaultconnection"));

        public UserRepository(
            IConfiguration config
        )
        {
            this.config = config;
        }

        public List<ApplicationUser> GetAll()
        {
            using var db = Connection;
            var sql = "SELECT id, username, full_name FROM users";

            return db.Query<ApplicationUser>(sql).ToList();
        }
    }
}
