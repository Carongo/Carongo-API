using Comum.Commands;
using Comum.Handlers;
using Dominio.Commands.AlunoResponses;
using Dominio.Commands.TurmaRequests;
using Dominio.Entidades;
using Dominio.Repositorios;

namespace Dominio.Handlers.Commands.Turmas
{
    public class AdicionarAlunoCommandHandler : IHandlerCommand<AdicionarAlunoCommand>
    {
        private ITurmaRepositorio TurmaRepositorio { get; set; }
        private IAlunoRepositorio AlunoRepositorio { get; set; }

        public AdicionarAlunoCommandHandler(ITurmaRepositorio turmaRepositorio, IAlunoRepositorio alunoRepositorio)
        {
            TurmaRepositorio = turmaRepositorio;
            AlunoRepositorio = alunoRepositorio;
        }

        public ICommandResult Handle(AdicionarAlunoCommand command)
        {
            command.Validar();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos!", command.Notifications);

            var turma = TurmaRepositorio.Buscar(command.IdTurma);

            if(turma.Alunos.Find(a => a.CPF == command.CPF) != null)
                return new GenericCommandResult(false, "Já existe um aluno cadastrado nessa turma com o CPF informado!", command.CPF);

            if(turma.Alunos.Find(a => a.Email == command.Email) != null)
                return new GenericCommandResult(false, "Já existe um aluno cadastrado nessa turma com o email informado!", command.Email);

            if (turma.Alunos.Find(a => a.Nome == command.Nome) != null)
                return new GenericCommandResult(false, "Já existe um aluno cadastrado nessa turma com o nome informado!", command.Nome);

            var aluno = new Aluno(command.Nome, command.Email, command.DataNascimento, command.UrlFoto, command.CPF, turma.Id);

            AlunoRepositorio.Adicionar(aluno);

            var resultado = new AlunoGenericCommandResult(aluno.Nome, aluno.Email, aluno.DataNascimento, aluno.UrlFoto, aluno.CPF);

            return new GenericCommandResult(true, "Aluno cadastrado com sucesso!", resultado);
        }
    }
}