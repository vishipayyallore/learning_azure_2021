using Microsoft.EntityFrameworkCore;

namespace FirstSample30
{

    public class CollegeDbContext : DbContext
    {
        public CollegeDbContext(DbContextOptions<CollegeDbContext> options) : base(options)
        {

        }

    }

}