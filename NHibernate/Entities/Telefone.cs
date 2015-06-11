namespace NHibernate.Entities
{
    public class Telefone : Entity
    {
        public virtual int Ddd { get; set; }
        public virtual string Numero { get; set; }
        public virtual TipoTelefone TipoTelefone { get; set; }

        public static Telefone Create()
        {
            return new Telefone
            {
                Numero = "3333-3333",
                Ddd = 11,
                TipoTelefone = TipoTelefone.Residencial
            };
        }
    }
}