namespace NHibernate.Test.Entities
{
    public class Estado : Entity
    {
        public virtual string Nome { get; set; }
        public virtual string Sigla { get; set; }

        public static Estado Create()
        {
            return new Estado
            {
                Nome = "São Paulo",
                Sigla = "SP"
            };
        }
    }
}