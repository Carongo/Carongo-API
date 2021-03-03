using Comum.Entidades;
using System;

namespace Dominio.Entidades
{
    public class Aluno : Entidade
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; set; }
        public string UrlFoto { get; set; }
        public string CPF { get; set; }

        public Aluno(string nome, string email, DateTime dataNascimento, string urlFoto, string cPF)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            UrlFoto = urlFoto;
            CPF = cPF;
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