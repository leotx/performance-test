using System;
using System.Configuration;
using Microsoft.Data.Entity;

namespace EntityFramework
{
    public class ClienteContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cliente>().Key(v => v.Id);

            base.OnModelCreating(builder);
        }
    }
}