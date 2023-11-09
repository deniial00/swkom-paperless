using System.Data.Entity;
using NPaperless.DataAccess.Entities;
using Npgsql;

namespace NPaperless.DataAccess.Sql
{
    public class NPaperlessDbContext : DbContext
    {
        public DbSet<Correspondent> Correspondents { get; set; }
        public DbSet<DocTag> DocTags { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        public NPaperlessDbContext() : base(new NpgsqlConnection("Host=localhost; Database=swkom; Username=swkom; Password=qZuggmsKEU5iCgWZ"), true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigureEntities(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureEntities(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Correspondent>();
            modelBuilder.Entity<DocTag>();
            modelBuilder.Entity<Document>();
            modelBuilder.Entity<DocumentType>();
            modelBuilder.Entity<UserInfo>();
        }
    }
}
