using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NPaperless.DataAccess.Entities;


namespace NPaperless.DataAccess.Sql
{
    public class NPaperlessDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Correspondent> Correspondents { get; set; }
        public DbSet<DocTag> DocTags { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        public NPaperlessDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));            
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.HasPostgresExtension("postgis");

            // builder.Entity<Company>()
            //     .HasMany(p=>p.Employees)
            //     .WithOne(p=>p.Company)
            //     .OnDelete(DeleteBehavior.SetNull);

            // builder.Entity<Company>()
            //     .Property(p => p.Version)
            //     .IsRowVersion();

            // builder.Entity<Person>()
            //     .Property(p => p.LastName)
            //     .IsConcurrencyToken();
            // builder.Entity<Person>()
            //     .Property(p => p.FirstName)
            //     .IsConcurrencyToken();
        }

        // private void ConfigureEntities(DbModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Correspondent>();
        //     modelBuilder.Entity<DocTag>();
        //     modelBuilder.Entity<Document>();
        //     modelBuilder.Entity<DocumentType>();
        //     modelBuilder.Entity<UserInfo>();
        // }
    }
}