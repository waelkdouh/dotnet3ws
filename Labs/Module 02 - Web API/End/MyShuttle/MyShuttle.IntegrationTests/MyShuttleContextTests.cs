using Xunit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyShuttle.Data;

namespace MyShuttle.IntegrationTests
{
    public class MyShuttleContextTests
    {
        [Fact]
        public async Task Db_CreatedSuccessfully()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase("MyShuttleTestDb");

            var context = new MyShuttleContext(optionsBuilder.Options);

            var databaseCreated = await context.Database.EnsureCreatedAsync();
            Assert.True(databaseCreated);

            var databaseDeleted = await context.Database.EnsureDeletedAsync();
            Assert.True(databaseDeleted);

        }
    }
}
