using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using technostar_test.Models;

namespace technostar_test
{
    public class TechnostarDbContext : DbContext
    {
        public TechnostarDbContext(DbContextOptions<TechnostarDbContext> options)
            : base(options)
        {

        }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
