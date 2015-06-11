namespace NHibernate.Entities
{
    public class Endereco : Entity
    {
        public virtual string Logradouro { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cep { get; set; }
        public virtual Estado Estado { get; set; } 
        public virtual Pais Pais { get; set; }
        public virtual Cidade Cidade { get; set; }

        public static Endereco Create()
        {
            return new Endereco
            {
                Logradouro = "Rua ABC",
                Numero = "123",
                Bairro = "Jardim",
                Cep = "13500-000",
            };
        }
    }
}