using Comum.Commands;
using Comum.Handlers;
using Dominio.Commands.TurmaRequests;
using Dominio.Repositorios;
using System;

namespace Dominio.Handlers.Commands.Turmas
{
    public class AlterarTurmaCommandHandler : IHandlerCommand<AlterarTurmaCommand>
    {
        private ITurmaRepositorio TurmaRepositorio { get; set; }

        public AlterarTurmaCommandHandler(ITurmaRepositorio turmaRepositorio)
        {
            TurmaRepositorio = turmaRepositorio;
        }

        public ICommandResult Handle(AlterarTurmaCommand command)
        {
            command.Validar();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos!", command.Notifications);

            var turma = TurmaRepositorio.Buscar(command.IdTurma);

            if(turma == null)
                return new GenericCommandResult(false, "Turma inexistente!", command.IdTurma);

            turma.Alterar(command.Nome);

            TurmaRepositorio.Alterar(turma);

            return new GenericCommandResult(true, "Turma alterada com sucesso!", turma.Nome);
        }
    }
}