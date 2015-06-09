using System;

namespace NHibernate
{
    public class Cliente
    {
        public virtual long Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Sobrenome { get; set; }
        public virtual string Usuario { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime Nascimento { get; set; }
        public virtual int EstadoCivil { get; set; }
        public virtual string Observacoes { get; set; }
    }
}