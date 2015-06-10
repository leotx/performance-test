using System;
using Microsoft.Data.Entity.Metadata.Builders;

namespace EntityFramework
{
    public class ClienteMap
    {
        public static Action<EntityTypeBuilder<Cliente>> BuildAction()
        {
            return e =>
            {
                e.Key(x => x.Id);
                e.Property(x => x.Email).MaxLength(100);
                e.Property(x => x.Sobrenome).MaxLength(100);
                e.Property(x => x.EstadoCivil).MaxLength(100);
                e.Property(x => x.Nome).MaxLength(100);
                e.Property(x => x.Senha).MaxLength(20);
                e.Property(x => x.Usuario).MaxLength(50);
            };
        }
    }
}