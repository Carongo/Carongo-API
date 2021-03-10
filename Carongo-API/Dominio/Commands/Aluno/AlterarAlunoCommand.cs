using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Commands.Aluno
{
    class AlterarAlunoCommand
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string UrlFoto { get; private set; }
        public string CPF { get; private set; }
        public Guid IdTurma { get; private set; }
        public Turma Turma { get; private set; }
    }
}
