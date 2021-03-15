using Comum.Commands;
using Comum.Handlers;
using Dominio.Commands.AlunoRequests;
using Dominio.Commands.AlunoResponses;
using Dominio.Repositorios;

namespace Dominio.Handlers.Commands.Alunos
{
    public class AlterarAlunoCommandHandler : IHandlerCommand<AlterarAlunoCommand>
    {
        private IAlunoRepositorio Repository { get; set; }

        public AlterarAlunoCommandHandler(IAlunoRepositorio repository)
        {
            Repository = repository;
        }

        public ICommandResult Handle(AlterarAlunoCommand command)
        {
            command.Validar();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos!", command.Notifications);

            var aluno = Repository.Buscar(command.IdAluno);

            if (aluno == null)
                return new GenericCommandResult(false, "Aluno inexistente!", command.IdAluno);

            aluno.Alterar(command.Nome, command.Email, command.DataNascimento, command.UrlFoto, command.CPF);

            Repository.Alterar(aluno);

            var result = new AlunoGenericCommandResult(aluno.Nome, aluno.Email, aluno.DataNascimento, aluno.CPF, aluno.UrlFoto);

            return new GenericCommandResult(true, "Informação(ões) de aluno alterada(s) com sucesso!", result);
        }
    }
}