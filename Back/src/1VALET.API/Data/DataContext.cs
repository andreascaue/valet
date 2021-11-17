using Microsoft.EntityFrameworkCore;

namespace _1VALET.API.Controllers
{

    public class DataContext : DbContext
    {

        public DataContext() { }

        public DataContext(DbContextOptions<DbContext> options) : base(options) { }

        public DbSet<Device> Devices { get; set; }


        /// <summary>
        /// https://elanderson.net/2019/11/entity-framework-core-no-database-provider-has-been-configured-for-this-dbcontext/
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite("DataSource=VALET.db");

    }

}

