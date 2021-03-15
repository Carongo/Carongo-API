using Comum.Commands;
using Comum.Handlers;
using Dominio.Commands.InstituicaoRequests;
using Dominio.Commands.InstituicaoResponses;
using Dominio.Repositorios;

namespace Dominio.Handlers.Commands.Instituicoes
{
    public class AlterarInstituicaoCommandHandler : IHandlerCommand<AlterarInstituicaoCommand>
    {
        private IInstituicaoRepositorio Repository { get; set; }

        public AlterarInstituicaoCommandHandler(IInstituicaoRepositorio repository)
        {
            Repository = repository;
        }

        public ICommandResult Handle(AlterarInstituicaoCommand command)
        {
            command.Validar();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos!", command.Notifications);

            var insti = Repository.Buscar(command.IdInstituicao);

            if (insti == null)
                return new GenericCommandResult(false, "Instituição inexistente!", command.IdInstituicao);

            insti.Alterar(command.Nome, command.Descricao);

            insti = Repository.Alterar(insti);

            var result = new InstituicaoGenericCommandResult(insti.Nome, insti.Descricao, insti.Codigo);

            return new GenericCommandResult(true, "Informação(ões) da instituição alterada(s)", result);
        }
    }
}