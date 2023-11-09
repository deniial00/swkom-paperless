namespace NPaperless.DataAccess.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
        public void Can_Create_NPaperlessDbContext()
        {
            using (var context = new Sql.NPaperlessDbContext())
            {
                context.Database.Connection.Open();
                Assert.True(context.Database.Connection.State == System.Data.ConnectionState.Open);
            }
        }
}