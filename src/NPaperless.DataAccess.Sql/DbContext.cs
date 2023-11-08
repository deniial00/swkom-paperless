using System.Data.Entity;
using Npgsql;

namespace NPaperless.DataAccess.Sql
{
    public class NPaperlessDbContext : DbContext
     {
         public NPaperlessDbContext() : base(new NpgsqlConnection("Host=localhost; Database=swkom; Username=swkom; Password=qZuggmsKEU5iCgWZ"), true)
         {
         }
     }
}
