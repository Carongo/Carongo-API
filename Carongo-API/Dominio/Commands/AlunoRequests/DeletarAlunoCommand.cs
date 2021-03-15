using Comum.Commands;
using System;

namespace Dominio.Commands.AlunoRequests
{
    public class DeletarAlunoCommand : ICommand
    {
        public Guid IdAluno { get; set; }

        public void Validar(){}
    }
}