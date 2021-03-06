using Comum.Entidades;
using System;

namespace Dominio.Entidades
{
    public class AlunoTurma : Entidade
    {
        public Guid IdAluno { get; private set; }
        public Aluno Aluno { get; private set; }
        public Guid IdTurma { get; private set; }
        public Turma Turma { get; private set; }
    }
}