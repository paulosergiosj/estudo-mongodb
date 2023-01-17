using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Infra.Tests
{
    public class DbFixture // : IDisposable
    {
        public MongoDbContextSettings DbContextSettings { get; }
        public MongoDbContext DbContext { get; }

        public DbFixture()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connString = config.GetConnectionString("db");
            var dbName = $"test_db_{Guid.NewGuid()}";

            this.DbContextSettings = new MongoDbContextSettings(connString, dbName);
            this.DbContext = new MongoDbContext(this.DbContextSettings);
        }

        public void Dispose()
        {
            var client = new MongoClient(this.DbContextSettings.ConnectionString);
            client.DropDatabase(this.DbContextSettings.DatabaseName);
        }
    }
}
