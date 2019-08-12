using FirstSample30.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstSample30.Persistence
{

    public class CollegeDbContext : DbContext
    {
        public CollegeDbContext(DbContextOptions<CollegeDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseCosmos(
                "https://localhost:8081/",
                "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                "webapidemodb" );
        }

        public DbSet<Professor> Professors { get; set; }

        public DbSet<Student> Students { get; set; }

    }

}