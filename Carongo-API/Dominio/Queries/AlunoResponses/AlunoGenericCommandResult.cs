using System;

namespace Dominio.Queries.AlunoResponses
{
    public class AlunoGenericCommandResult
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string UrlFoto { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }

        public AlunoGenericCommandResult(string nome, string email, string urlFoto, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            UrlFoto = urlFoto;
            CPF = cpf;
            DataNascimento = dataNascimento;
        }
    }
}