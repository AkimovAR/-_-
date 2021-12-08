using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using motoStore.Models;

namespace motoStore.DAL
{
    class MotoContext : DbContext
    {
        public MotoContext()
          : base("moto")
        {  }
        public virtual DbSet<Bike> Bikes { get; set; }
        public  DbSet<Bikeshop> Bikeshops { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Discount> Discounts { get; set; }

    }
}
