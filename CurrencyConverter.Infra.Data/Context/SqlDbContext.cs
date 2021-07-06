using CurrencyConverter.Domain.Entities;
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
    }
}
