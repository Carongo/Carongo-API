using Comum.Commands;
using Comum.Handlers;
using Dominio.Commands.InstituicaoRequests;
using Dominio.Entidades;
using Dominio.Repositorios;
using System;

namespace Dominio.Handlers.Commands.Instituicoes
{
    public class AdicionarTurmaCommandHandler : IHandlerCommand<AdicionarTurmaCommand>
    {
        private IInstituicaoRepositorio InstituicaoRepositorio { get; set; }
        private ITurmaRepositorio TurmaRepositorio { get; set; }

        public AdicionarTurmaCommandHandler(IInstituicaoRepositorio instituicaoRepositorio, ITurmaRepositorio turmaRepositorio)
        {
            InstituicaoRepositorio = instituicaoRepositorio;
            TurmaRepositorio = turmaRepositorio;
        }

        public ICommandResult Handle(AdicionarTurmaCommand command)
        {
            command.Validar();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos!", command.Notifications);

            var instituicao = InstituicaoRepositorio.Buscar(command.IdInstituicao);

            if(instituicao.Turmas.Find(t => t.Nome == command.Nome) != null)
                return new GenericCommandResult(false, "Essa instituição já tem uma turma com esse nome. Escolha outro!", command.Nome);

            var turma = new Turma(command.Nome, instituicao.Id);

            TurmaRepositorio.Adicionar(turma);

            return new GenericCommandResult(false, "Turma cadastrada com sucesso!", command.Nome);
        }
    }
}