using Comum.Handlers;
using Comum.Queries;
using Dominio.Queries.InstituicaoRequests;
using Dominio.Queries.InstituicaoResponses;
using Dominio.Repositorios;
using System.Linq;

namespace Dominio.Handlers.Queries.Instituicoes
{
    public class ListarMinhasInstituicoesQueryHandler : IHandlerQuery<ListarMinhasInstituicoesQuery>
    {
        private IInstituicaoRepositorio Repositorio { get; set; }

        public ListarMinhasInstituicoesQueryHandler(IInstituicaoRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public IQueryResult Handle(ListarMinhasInstituicoesQuery query)
        {
            var minhasInstituicoes = Repositorio.Listar(query.IdUsuario, query.Nome);

            var resultado = minhasInstituicoes.Select(
                i =>
                {
                    return new ListarMinhasInstituicoesQueryResult(i.Id, i.Nome, i.Descricao.Substring(0, i.Descricao.Length > 20 ? 20 : 19) + "...", i.UsuariosInstituicoes.Find(ui => ui.IdUsuario == query.IdUsuario).Tipo.ToString());
                }
            );

            if(resultado.Count() > 0)
                return new GenericQueryResult(true, "Instituições das quais você faz parte!", resultado);

            if (query.Nome != null)
                return new GenericQueryResult(true, "Nenhuma instituição encontrada!", "Nenhuma instituição encontrada!");

            return new GenericQueryResult(true, "Você não faz parte de nenhuma instituição!", "Você não faz parte de nenhuma instituição! Que tal criar ou entrar em uma?");
        }
    }
}