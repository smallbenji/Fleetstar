using System.Text.Json;
using Fleetstar.Helper;
using Npgsql;

namespace Fleetstar.Components
{
    public class BookingRepository
    {
        private readonly DBHelper db;

        public BookingRepository(DBHelper db)
        {
            this.db = db;
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            var dataSource = db.DbDatasource();
            using var conn = await dataSource.OpenConnectionAsync();

            var cmd = new NpgsqlCommand(@"
            INSERT INTO bookings (id, data)
            VALUES (@Id, @Data)
            ", conn);

            cmd.Parameters.AddWithValue("Id", booking.Id);
            cmd.Parameters.AddWithValue("Data", NpgsqlTypes.NpgsqlDbType.Jsonb, JsonSerializer.Serialize(booking));

            await cmd.ExecuteNonQueryAsync();

            return booking;
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            var retval = new List<Booking>();
            var dataSource = db.DbDatasource();
            using var conn = await dataSource.OpenConnectionAsync();

            var cmd = new NpgsqlCommand(@"
            SELECT data
            FROM bookings
            ", conn); // Add the connection parameter here

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    retval.Add(JsonSerializer.Deserialize<Booking>(reader.GetString(0)));
                }
            }

            return retval;
        }
    }

    public class Booking
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime BookingDateFrom { get; set; }
        public DateTime BookingDateTo { get; set; }
    }
}