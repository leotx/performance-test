namespace NHibernate.Entities
{
    public class Pais : Entity
    {
        public virtual string Nome { get; set; }
        public virtual Continente Continente { get; set; }

        public static Pais Create()
        {
            return new Pais
            {
                Nome = "Brasil",
                Continente = Continente.America
            };
        }
    }
}