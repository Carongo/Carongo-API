using Comum.Commands;
using Comum.Handlers;
using Dominio.Commands.AlunoRequests;
using Dominio.Repositorios;

namespace Dominio.Handlers.Commands.Alunos
{
    public class DeletarAlunoCommandHandler : IHandlerCommand<DeletarAlunoCommand>
    {
        private IAlunoRepositorio Repository { get; set; }

        public DeletarAlunoCommandHandler(IAlunoRepositorio repository)
        {
            Repository = repository;
        }

        public ICommandResult Handle(DeletarAlunoCommand command)
        {
            var aluno = Repository.Buscar(command.IdAluno);

            if (aluno == null)
                return new GenericCommandResult(false, "Aluno inexistente!", command.IdAluno);

            Repository.Deletar(aluno.Id);

            return new GenericCommandResult(true, "Aluno deletado com sucesso!", null);
        }
    }
}