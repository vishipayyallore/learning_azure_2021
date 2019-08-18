using CosmosDbDemo1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDbDemo1.Persistence
{

    public class NoSqlDbContext : DbContext
    {
        public NoSqlDbContext(DbContextOptions<NoSqlDbContext> options)
            : base(options) { }

        public DbSet<BookListNoSql> Books { get; set; }

        //thanks to https://csharp.christiannagel.com/2018/09/05/efcorecosmos/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //see this for timestamp https://docs.microsoft.com/en-us/azure/cosmos-db/working-with-dates#storing-datetimes
            modelBuilder.Entity<BookListNoSql>().Property<long>("_ts").ValueGeneratedOnAddOrUpdate();
        }
    }

}
