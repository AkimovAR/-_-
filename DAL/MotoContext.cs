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
        public  virtual  DbSet<Bike> Bikes { get; set; }
        public  virtual  DbSet<Bikeshop> Bikeshops { get; set; }
        public  virtual DbSet<Client> Clients { get; set; }
        public  virtual DbSet<Employee> Employees { get; set; }
        public  virtual DbSet<Order> Orders { get; set; }
        public  virtual DbSet<Discount> Discounts { get; set; }
                
    }           
}               
