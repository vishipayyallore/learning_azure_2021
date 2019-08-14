using FirstSample30.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstSample30.Persistence
{

    public class CollegeDbContext : DbContext
    {
        public CollegeDbContext(DbContextOptions<CollegeDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        //{
        //    dbContextOptionsBuilder.UseCosmos(
        //        "https://localhost:8081/",
        //        "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
        //        "webapidemodb" );
        //}

        public DbSet<Professor> Professors { get; set; }

        //public DbSet<Student> Students { get; set; }

        //thanks to https://csharp.christiannagel.com/2018/09/05/efcorecosmos/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //see this for timestamp https://docs.microsoft.com/en-us/azure/cosmos-db/working-with-dates#storing-datetimes
            modelBuilder.Entity<Professor>().Property<long>("_ts").ValueGeneratedOnAddOrUpdate();
        }

    }

}