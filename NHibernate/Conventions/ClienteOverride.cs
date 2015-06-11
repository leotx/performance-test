using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using NHibernate.Entities;

namespace NHibernate.Conventions
{
    public class ClienteOverride : IAutoMappingOverride<Cliente>
    {
        public void Override(AutoMapping<Cliente> mapping)
        {
            mapping.Id(x => x.Id);
            mapping.Map(x => x.Email).Length(100);
            mapping.Map(x => x.Sobrenome).Length(100);
            mapping.Map(x => x.Nome).Length(100);
            mapping.Map(x => x.Senha).Length(20);
            mapping.Map(x => x.Usuario).Length(50);
            mapping.Map(x => x.Observacoes).CustomType("StringClob").CustomSqlType("nvarchar(max)");
        }
    }
}