using GCCarDealership.Model;
using Microsoft.EntityFrameworkCore;

namespace GCCarDealership.Data
{
    public class CarsContext : DbContext
    {
        public CarsContext(DbContextOptions<CarsContext> options)
            : base(options)
        {

        }

        public DbSet<Cars> Cars { get; set; }
    }
}
