using System;

namespace Dominio.Commands.UsuarioResponses
{
    public class UsuarioGenericCommandResult
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public UsuarioGenericCommandResult(Guid id, DateTime dataCriacao, string nome, string email)
        {
            Id = id;
            DataCriacao = dataCriacao;
            Nome = nome;
            Email = email;
        }
    }
}