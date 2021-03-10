using Comum.Commands;
using Comum.Handlers;
using Dominio.Commands.UsuarioRequests;
using Dominio.Repositorios;

namespace Dominio.Handlers.Commands.Usuarios
{
    public class DeletarContaCommandHandler : IHandlerCommand<DeletarContaCommand>
    {
        private IUsuarioRepositorio Repositorio { get; set; }

        public DeletarContaCommandHandler(IUsuarioRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public ICommandResult Handle(DeletarContaCommand command)
        {
            var usuario = Repositorio.Buscar(command.IdUsuario);

            if (usuario == null)
                return new GenericCommandResult(false, "Usuário inexistente ou você não tem permissão para deletá-lo!", null);

            Repositorio.Deletar(usuario.Id);

            return new GenericCommandResult(true, "Usuário deletado com sucesso! Quando quiser voltar, estaremos à disposição.. :(", null);
        }
    }
}