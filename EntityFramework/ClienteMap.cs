using System.Data.Entity.ModelConfiguration;

namespace EntityFramework
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Email).HasMaxLength(100);
            Property(x => x.Sobrenome).HasMaxLength(100);
            Property(x => x.Nome).HasMaxLength(100);
            Property(x => x.Senha).HasMaxLength(20);
            Property(x => x.Usuario).HasMaxLength(50);
        }
    }
}