using Microsoft.EntityFrameworkCore;
using NPaperless.DA.Entities;
using Npgsql;

namespace NPaperless.DA.Sql
{
    public class NPaperlessDbContext : DbContext
    {
        public DbSet<Correspondent> Correspondents { get; set; }
        public DbSet<DocTag> DocTags { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        public NPaperlessDbContext(DbContextOptions<NPaperlessDbContext> options) : base(options)
        {
        }
    }
}
