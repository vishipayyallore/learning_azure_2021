using CosmosDbDemo1.Entities;
using Microsoft.EntityFrameworkCore;

namespace CosmosDbDemo1.Persistence
{

    public class CollegeDbContext : DbContext
    {
        public CollegeDbContext(DbContextOptions<CollegeDbContext> options) : base(options)
        {
        }


        public DbSet<Professor> Professors { get; set; }

        //thanks to https://csharp.christiannagel.com/2018/09/05/efcorecosmos/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //see this for timestamp https://docs.microsoft.com/en-us/azure/cosmos-db/working-with-dates#storing-datetimes
            modelBuilder.Entity<Professor>().Property<long>("_ts").ValueGeneratedOnAddOrUpdate();
        }

    }

}
