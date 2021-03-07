using Comum.Entidades;
using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Turma : Entidade
    {
        public string Nome { get; private set; }
        public Guid IdInstituicao { get; private set; }
        public Instituicao Instituicao { get; private set; }
        public List<Aluno> Alunos { get; }

        public Turma(string nome)
        {
            Nome = nome;
            Alunos = new List<Aluno>();
        }

        public void Alterar(string nome)
        {
            if (nome != Nome)
                Nome = nome;
        }
    }
}