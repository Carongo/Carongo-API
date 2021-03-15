using Comum.Commands;
using Flunt.Notifications;
using System;

namespace Dominio.Commands.TurmaRequests
{
    public class DeletarTurmaCommand : ICommand
    {
        public Guid IdTurma { get; set; }

        public void Validar(){}
    }
}