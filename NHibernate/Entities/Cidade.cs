namespace NHibernate.Entities
{
    public class Cidade : Entity
    {
        public virtual string Nome { get; set; }

        public static Cidade Create()
        {
            return new Cidade
            {
                Nome = "São Paulo"
            };
        }
    }
}