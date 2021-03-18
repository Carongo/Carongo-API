using Comum.Handlers;
using Comum.Queries;
using Dominio.Commands.AlunoResponses;
using Dominio.Queries.AlunoRequests;
using Dominio.Repositorios;

namespace Dominio.Handlers.Queries.Alunos
{
    public class ListarAlunoPorIdQueryHandler : IHandlerQuery<ListarAlunoPorIdQuery>
    {
        private IAlunoRepositorio Repositorio { get; set; }

        public ListarAlunoPorIdQueryHandler(IAlunoRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public IQueryResult Handle(ListarAlunoPorIdQuery query)
        {
            var aluno = Repositorio.Buscar(query.IdAluno);

            var result = new AlunoGenericCommandResult(aluno.Nome, aluno.Email, aluno.DataNascimento, aluno.UrlFoto, aluno.CPF);

            return new GenericQueryResult(true, "Detalhes do aluno", result);
        }
    }
}