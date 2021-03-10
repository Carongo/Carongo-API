using System;

namespace Dominio.Commands.AlunoResponses
{
    public class AlunoGenericCommandResult
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string UrlFoto { get; set; }
        public string CPF { get; set; }

        public AlunoGenericCommandResult(string nome, string email, DateTime dataNascimento, string urlFoto, string cpf)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            UrlFoto = urlFoto;
            CPF = cpf;
        }
    }
}