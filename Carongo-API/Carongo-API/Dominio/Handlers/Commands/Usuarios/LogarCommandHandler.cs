using Comum.Utils;
using Comum.Commands;
using Comum.Handlers;
using Dominio.Commands.UsuarioRequests;
using Dominio.Repositorios;

namespace Dominio.Handlers.Commands.Usuarios
{
    public class LogarCommandHandler : IHandlerCommand<LogarCommand>
    {
        private IUsuarioRepositorio Repositorio { get; set; }

        public LogarCommandHandler(IUsuarioRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public ICommandResult Handle(LogarCommand command)
        {
            command.Validar();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos!", command.Notifications);

            var usuario = Repositorio.Buscar(command.Email);

            if (usuario == null)
                return new GenericCommandResult(false, "Não existe nenhum usuário cadastrado com o email informado!", command.Email);

            if (!Senha.Validar(command.Senha, usuario.Senha))
                return new GenericCommandResult(false, "Senha incorreta!", command.Senha);

            return new GenericCommandResult(true, "Logado com sucesso!", usuario);
        }
    }
}