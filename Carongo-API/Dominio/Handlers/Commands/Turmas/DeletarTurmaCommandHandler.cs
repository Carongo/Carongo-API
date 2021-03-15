using Comum.Commands;
using Comum.Handlers;
using Dominio.Commands.TurmaRequests;
using Dominio.Repositorios;
using System;

namespace Dominio.Handlers.Commands.Turmas
{
    public class DeletarTurmaCommandHandler : IHandlerCommand<DeletarTurmaCommand>
    {
        private ITurmaRepositorio TurmaRepositorio { get; set; }

        public DeletarTurmaCommandHandler(ITurmaRepositorio turmaRepositorio)
        {
            TurmaRepositorio = turmaRepositorio;
        }

        public ICommandResult Handle(DeletarTurmaCommand command)
        {
            TurmaRepositorio.Deletar(command.IdTurma);

            return new GenericCommandResult(true, "Turma deletada com sucesso!", null);
        }
    }
}