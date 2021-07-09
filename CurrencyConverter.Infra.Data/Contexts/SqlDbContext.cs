using CurrencyConverter.Domain.Entities;
using CurrencyConverter.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Infra.Data.Context
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Currencies> Currencies { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();

            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new TransactionsMap());
            modelBuilder.ApplyConfiguration(new CurrenciesMap());
        }
    }
}
