using FirstSample30.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstSample30.Persistence
{

    public class CollegeDbContext : DbContext
    {
        public CollegeDbContext(DbContextOptions<CollegeDbContext> options) : base(options)
        {

        }

        public DbSet<Professor> Professors { get; set; }

        public DbSet<Student> Students { get; set; }

    }

}