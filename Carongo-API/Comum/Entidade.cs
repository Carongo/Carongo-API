using System;

namespace Comum
{
    public abstract class Entidade
    {
        public Guid Id { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public Entidade()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
        }
    }
}