using Npgsql;

namespace Fleetstar.Helper
{
    public class DBHelper
    {
        private readonly IConfiguration config;

        public DBHelper(IConfiguration config)
        {
            this.config = config;
        }

        public NpgsqlDataSource DbDatasource()
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(config.GetConnectionString("DefaultConnection"));
            return dataSourceBuilder.Build();
        }
    }
}