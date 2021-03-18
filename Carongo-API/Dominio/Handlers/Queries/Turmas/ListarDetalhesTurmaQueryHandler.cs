using Comum.Handlers;
using Comum.Queries;
using Dominio.Queries.TurmaRequests;
using Dominio.Queries.TurmaResponses;
using Dominio.Repositorios;

namespace Dominio.Handlers.Queries.Turmas
{
    public class ListarDetalhesTurmaQueryHandler : IHandlerQuery<ListarDetalhesTurmaQuery>
    {
        private ITurmaRepositorio Repositorio { get; set; }

        public ListarDetalhesTurmaQueryHandler(ITurmaRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public IQueryResult Handle(ListarDetalhesTurmaQuery query)
        {
            var turma = Repositorio.Buscar(query.IdTurma);

            var result = new TurmaGenericCommandResult(turma.Nome);

            return new GenericQueryResult(true, "Detalhes da turma", result);
        }
    }
}