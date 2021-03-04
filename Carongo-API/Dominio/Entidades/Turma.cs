using Comum.Entidades;
using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Turma : Entidade
    {
        public string Nome { get; private set; }
        public string Disciplina { get; private set; }
        public string Descricao { get; private set; }
        public List<Aluno> Alunos { get; }
        public Guid IdInstituicao { get; private set; }
        public Instituicao Instituicao { get; private set; }

        public Turma(string nome, string disciplina, string descricao)
        {
            Nome = nome;
            Disciplina = disciplina;
            Descricao = descricao;
        }

        public void Alterar(string nome, string disciplina, string descricao)
        {
            if (nome != Nome)
                Nome = nome;

            if (disciplina != Disciplina)
                Disciplina = disciplina;

            if (descricao != Descricao)
                Descricao = descricao;
        }
    }
}