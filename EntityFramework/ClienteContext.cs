using System.Data.Entity;

namespace EntityFramework
{
    public class ClienteContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }

        public ClienteContext() : base("defaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Configurations.Add(new ClienteMap());
        }
    }
}