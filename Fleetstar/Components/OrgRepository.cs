using Npgsql;

namespace Fleetstar.Components
{
    public class OrgRepository
    {
        private readonly IConfiguration config;

        public OrgRepository(IConfiguration config)
        {
            this.config = config;
        }

        private NpgsqlConnection Connection => new NpgsqlConnection(config.GetConnectionString("DefaultConnection"));
    
    
        public async Task<Org> GetOrgAsync(string orgId)
        {
            var sql = "";

            using var db = Connection;
            var cmd = new NpgsqlCommand(sql, db);

            return new Org();
            
        }

    }

    public class Org
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
    }
}
