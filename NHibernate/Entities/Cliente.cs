using System;
using System.Collections.Generic;

namespace NHibernate.Entities
{
    public class Cliente : Entity
    {
        public virtual string Nome { get; set; }
        public virtual string Sobrenome { get; set; }
        public virtual string Usuario { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime Nascimento { get; set; }
        public virtual string Observacoes { get; set; }
        public virtual string CpfCnpj { get; set; }
        public virtual EstadoCivil EstadoCivil { get; set; }
        public virtual TipoPessoa TipoPessoa { get; set; }
        public virtual IList<Endereco> Enderecos { get; set; }
        public virtual IList<Telefone> Telefones { get; set; }

        public Cliente()
        {
            Enderecos = new List<Endereco>();
            Telefones = new List<Telefone>();
        }

        public static Cliente Create()
        {
            var cliente = new Cliente
            {
                Nome = "John",
                Sobrenome = "Doe",
                Email = "john@doe.com.br",
                EstadoCivil = EstadoCivil.Casado,
                Nascimento = new DateTime(2002, 11, 20),
                Usuario = "JD",
                Senha = "JD123",
                Observacoes = "1".PadLeft(1000, '1'),
                CpfCnpj = "999.999.999-99",
                TipoPessoa = TipoPessoa.Fisica
            };

            return cliente;
        }

        public static Cliente CreateWithRelationship(int numberOfRelationships)
        {
            var cliente = Create();

            for (var iC = 0; iC < numberOfRelationships; iC++)
            {
                cliente.Enderecos.Add(Endereco.Create());
                cliente.Telefones.Add(Telefone.Create());
            }

            return cliente;
        }
    }
}