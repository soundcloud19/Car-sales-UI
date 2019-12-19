using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Car_sales_UI
{
    public class CarSalesContext : DbContext
    {
        public CarSalesContext(DbContextOptions<CarSalesContext> options)
            : base(options)
        {
        }

        public DbSet<Sale> Sale { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<RefModelTypes> RefModelTypes { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }

    }
}
