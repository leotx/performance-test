using FluentNHibernate.Automapping;

namespace NHibernate
{
    public class AutoMappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(System.Type type)
        {
            return type == typeof (Cliente);
        }
    }
}