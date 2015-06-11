using FluentNHibernate.Automapping;
using NHibernate.Entities;

namespace NHibernate.Conventions
{
    public class AutoMappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(System.Type type)
        {
            return type.IsSubclassOf(typeof(Entity));
        }
    }
}