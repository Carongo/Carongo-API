using Comum.Commands;
using Comum.Handlers;
using Dominio.Commands.Aluno;
using Dominio.Entidades;
using Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Handlers.Commands.Alunos
{
    public class AdicionarAlunoCommandHandler : IHandlerCommand<AdicionarAlunoCommand>
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AdicionarAlunoCommandHandler(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public ICommandResult Handle(AdicionarAlunoCommand command)
        {
            command.Validar();

            if (!command.IsValid)
                return new GenericCommandResult(false, "Dados invalidos", command.Notifications);

            var alunoex = _alunoRepositorio.BuscarPorNome(command.Email);

            if (alunoex != null)
                return new GenericCommandResult(false, "Aluno Cadastrado com esse email", null);

            var newAluno = _alunoRepositorio.BuscarPorNome(command.CPF);

            if (newAluno != null)
                return new GenericCommandResult(false, "Aluno Cadastrado com esse CPF", null);



            var aluno = new Aluno(command.Nome, command.Email, command.DataNascimento, command.UrlFoto, command.CPF);

            if (!command.IsValid)
                return new GenericCommandResult(false, "Dados invalidos", command.Notifications);

            _alunoRepositorio.Adicionar(aluno);

            return new GenericCommandResult(true, "Aluno criado", aluno);
        }
    }
}
