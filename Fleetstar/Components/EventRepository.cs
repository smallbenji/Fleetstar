using System.Text.Json;
using System.Threading.Tasks;
using Dapper;
using Fleetstar.Helper;
using Npgsql;

namespace Fleetstar.Components
{
    public class EventRepository
    {
        private readonly IConfiguration config;
        private readonly DBHelper db;

        public EventRepository(IConfiguration config, DBHelper db)
        {
            this.config = config;
            this.db = db;
        }

        public async Task<List<Event>> GetEvents()
        {
            var retval = new List<Event>();
            var sql = "SELECT data FROM events";
            var dataSource = db.DbDatasource();
            using var conn = await dataSource.OpenConnectionAsync();

            var cmd = new NpgsqlCommand(sql, conn);
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var jsonData = reader.GetString(0);
                retval.Add(JsonSerializer.Deserialize<Event>(jsonData));
            }

            return retval;
        }

        public async Task<Event> AddEvent(Event eventToAdd)
        {
            if (eventToAdd.Id == null)
            {
                eventToAdd.Id = Guid.NewGuid().ToString();
            }

            var dataSource = db.DbDatasource();
            using var conn = await dataSource.OpenConnectionAsync();

            var cmd = new NpgsqlCommand(@"
            INSERT INTO events (id, data)
                VALUES (@Id, @Data)
            ", conn);
            
            cmd.Parameters.AddWithValue("Id", eventToAdd.Id);
            cmd.Parameters.AddWithValue("Data", NpgsqlTypes.NpgsqlDbType.Jsonb, JsonSerializer.Serialize(eventToAdd));
            await cmd.ExecuteNonQueryAsync();
            return eventToAdd;
        }
    }

    public class Event
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string ForWho { get; set; }
        public List<object> extrafields { get; set; }
    }
}