using Microsoft.EntityFrameworkCore;
using NETCORE_ATM_TRANSACTION.Repository.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Models
{
    public class AtmDbContext :DbContext
    {
        public AtmDbContext(DbContextOptions<AtmDbContext> options)
        : base(options) //buynu değiştim to ctor
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactionss { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-OE95DLD\\MSSQLSERVER01;database=ATM-API-TRANSACTION; integrated security=true;");
        }
    }
}
