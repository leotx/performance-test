using System;

namespace EntityFramework.Test
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
        public int EstadoCivil { get; set; }
        public string Observacoes { get; set; }

        public static Cliente Create()
        {
            var cliente = new Cliente
            {
                Nome = "John",
                Sobrenome = "Doe",
                Email = "john@doe.com.br",
                EstadoCivil = 1,
                Nascimento = new DateTime(2002, 11, 20),
                Usuario = "JD",
                Senha = "JD123",
                Observacoes = "1".PadLeft(1000, '1')
            };

            return cliente;
        }
    }
}