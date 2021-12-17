using Microsoft.EntityFrameworkCore;
using Devices.Domain;

namespace Devices.Persistence.Context
{ 

    public class DevicesContext : DbContext
    {
        public DevicesContext(){}

        public DevicesContext(DbContextOptions<DbContext> options) : base(options) { }

        public DevicesContext(DbContextOptions options) : base(options) { }

        public DbSet<Device> Devices { get; set; }

    }

}

