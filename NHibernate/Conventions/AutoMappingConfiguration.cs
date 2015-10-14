using FluentNHibernate.Automapping;
using NHibernate.Test.Entities;

namespace NHibernate.Test.Conventions
{
    public class AutoMappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(System.Type type)
        {
            return type.IsSubclassOf(typeof(Entity));
        }
    }
}