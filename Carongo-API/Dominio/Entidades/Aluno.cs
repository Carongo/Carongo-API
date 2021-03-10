using Comum.Entidades;
using System;

namespace Dominio.Entidades
{
    public class Aluno : Entidade
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string UrlFoto { get; private set; }
        public string CPF { get; private set; }
        public Guid IdTurma { get; private set; }
        public Turma Turma { get; private set; }

        public Aluno(string nome, string email, DateTime dataNascimento, string urlFoto, string cPF, Guid idTurma)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            UrlFoto = urlFoto;
            CPF = cPF;
            IdTurma = idTurma;
        }

        public void Alterar(string nome, string email, DateTime dataNascimento, string urlFoto, string cPF)
        {
            if (nome != Nome)
                Nome = nome;

            if (email != Email)
                Email = email;

            if (dataNascimento != DataNascimento)
                DataNascimento = dataNascimento;

            if (urlFoto != UrlFoto)
                UrlFoto = urlFoto;

            if (cPF != CPF)
                CPF = cPF;
        }
    }
}