using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NPaperless.DataAccess.Sql;

namespace NPaperless.DataAccess.Test
{
    public class Tests
    {
        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            var appSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
            _configuration = new ConfigurationBuilder().AddJsonFile(appSettingsPath).Build();
        }

        [Test]
        public void Can_Create_NPaperlessDbContext()
        {
            //var optionsBuilder = new DbContextOptionsBuilder<NPaperlessDbContext>()
            //    .UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));

            using (var context = new NPaperlessDbContext(_configuration))
            {
                context.Database.OpenConnection();
                Assert.True(context.Database.GetDbConnection().State == System.Data.ConnectionState.Open);
            }
        }
    }
}
