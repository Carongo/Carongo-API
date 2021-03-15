using Comum.Handlers;
using Comum.Queries;
using Dominio.Queries.UsuarioRequests;
using Dominio.Queries.UsuarioResponses;
using Dominio.Repositorios;

namespace Dominio.Handlers.Queries.Usuarios
{
    public class ListarMeuPerfilQueryHandler : IHandlerQuery<ListarMeuPerfilQuery>
    {
        private IUsuarioRepositorio Repositorio { get; set; }

        public ListarMeuPerfilQueryHandler(IUsuarioRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public IQueryResult Handle(ListarMeuPerfilQuery query)
        {
            var usuario = Repositorio.Buscar(query.IdUsuario);

            var result = new ListarMeuPerfilQueryResult(usuario.Id, usuario.Nome, usuario.Email);

            return new GenericQueryResult(true, "Seu perfil!", result);
        }
    }
}