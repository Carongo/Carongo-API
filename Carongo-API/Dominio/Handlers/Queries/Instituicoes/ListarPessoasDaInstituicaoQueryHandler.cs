using Comum.Handlers;
using Comum.Queries;
using Dominio.Queries.InstituicaoRequests;
using Dominio.Repositorios;
using System.Linq;

namespace Dominio.Handlers.Queries.Instituicoes
{
    public class ListarPessoasDaInstituicaoQueryHandler : IHandlerQuery<ListarPessoasDaInstituicaoQuery>
    {
        private IInstituicaoRepositorio Repositorio { get; set; }

        public ListarPessoasDaInstituicaoQueryHandler(IInstituicaoRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public IQueryResult Handle(ListarPessoasDaInstituicaoQuery query)
        {
            var usuariosInstituicoes = Repositorio.Buscar(query.IdInstituicao).UsuariosInstituicoes;

            var usuarios = usuariosInstituicoes.Select(
                    ui =>
                    {
                        if(ui.Tipo == Comum.Enum.EnTipoUsuario.Colaborador)
                        {
                            return new
                            {
                                Tipo = Comum.Enum.EnTipoUsuario.Colaborador,
                                Id = ui.Usuario.Id,
                                Nome = ui.Usuario.Nome
                            };
                        }
                        else
                        {
                            return new
                            {
                                Tipo = Comum.Enum.EnTipoUsuario.Administrador,
                                Id = ui.Usuario.Id,
                                Nome = ui.Usuario.Nome
                            };
                        }
                    }
                );

            var result = new
            {
                Colaboradores = usuarios.Where(u => u.Tipo == Comum.Enum.EnTipoUsuario.Colaborador),
                Administradores = usuarios.Where(u => u.Tipo == Comum.Enum.EnTipoUsuario.Administrador)
            };

            return new GenericQueryResult(true, "Pessoas da instituição", result);
        }
    }
}