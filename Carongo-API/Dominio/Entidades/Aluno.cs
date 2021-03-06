using Comum.Entidades;
using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Aluno : Entidade
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string UrlFoto { get; private set; }
        public string CPF { get; private set; }
        public List<AlunoTurma> AlunosTurmas { get; }

        public Aluno(string nome, string email, DateTime dataNascimento, string urlFoto, string cPF)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            UrlFoto = urlFoto;
            CPF = cPF;
            AlunosTurmas = new List<AlunoTurma>();
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