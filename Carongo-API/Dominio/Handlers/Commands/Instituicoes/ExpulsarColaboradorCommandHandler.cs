using Comum.Commands;
using Comum.Handlers;
using Dominio.Commands.InstituicaoRequests;
using Dominio.Repositorios;

namespace Dominio.Handlers.Commands.Instituicoes
{
    public class ExpulsarColaboradorCommandHandler : IHandlerCommand<ExpulsarColaboradorCommand>
    {
        private IInstituicaoRepositorio Repositorio { get; set; }

        public ExpulsarColaboradorCommandHandler(IInstituicaoRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public ICommandResult Handle(ExpulsarColaboradorCommand command)
        {
            var instituicao = Repositorio.Buscar(command.IdInstituicao);

            var usuarioInstituicao = instituicao.UsuariosInstituicoes.Find(ui => ui.Id == command.IdUsuarioInstituicao);

            if(usuarioInstituicao==null)
                return new GenericCommandResult(false, "Usuário inexistente!", command.IdUsuarioInstituicao);

            Repositorio.DeletarUsuario(command.IdUsuarioInstituicao);

            return new GenericCommandResult(true, "Colaborador expulso com sucesso!", null);
        }
    }
}