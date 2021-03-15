using Comum.Commands;
using Comum.Handlers;
using Dominio.Commands.InstituicaoRequests;
using Dominio.Repositorios;

namespace Dominio.Handlers.Commands.Instituicoes
{
    public class DeletarInstituicaoCommandHandler : IHandlerCommand<DeletarInstituicaoCommand>
    {
        private IInstituicaoRepositorio Repository { get; set; }

        public DeletarInstituicaoCommandHandler(IInstituicaoRepositorio repository)
        {
            Repository = repository;
        }

        public ICommandResult Handle(DeletarInstituicaoCommand command)
        {
            var insti = Repository.Buscar(command.IdInstituicao);

            if (insti == null)
                return new GenericCommandResult(false, "Instituição inexistente!", null);

            Repository.Deletar(insti.Id);

            return new GenericCommandResult(true, "Instituição deletada com sucesso!", null);
        }
    }
}