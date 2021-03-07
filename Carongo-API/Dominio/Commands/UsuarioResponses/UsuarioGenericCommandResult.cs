using System;

namespace Dominio.Commands.UsuarioResponses
{
    public class UsuarioGenericCommandResult
    {
        public DateTime DataCriacao { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public UsuarioGenericCommandResult(DateTime dataCriacao, string nome, string email)
        {
            DataCriacao = dataCriacao;
            Nome = nome;
            Email = email;
        }
    }
}