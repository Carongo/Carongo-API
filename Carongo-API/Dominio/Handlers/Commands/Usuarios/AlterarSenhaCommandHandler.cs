using Comum.Commands;
using Comum.Handlers;
using Comum.Utils;
using Dominio.Commands.UsuarioRequests;
using Dominio.Repositorios;

namespace Dominio.Handlers.Commands.Usuarios
{
    public class AlterarSenhaCommandHandler : IHandlerCommand<AlterarSenhaCommand>
    {
        private IUsuarioRepositorio Repositorio { get; set; }

        public AlterarSenhaCommandHandler(IUsuarioRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public ICommandResult Handle(AlterarSenhaCommand command)
        {
            command.Validar();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos!", command.Notifications);

            var usuario = Repositorio.Buscar(command.IdUsuario);

            if(!Senha.Validar(command.SenhaAtual, usuario.Senha))
                return new GenericCommandResult(false, "Senha atual incorreta!", command.SenhaAtual);

            var senhaCriptografada = Senha.Criptografar(command.SenhaNova);

            usuario.AlterarSenha(senhaCriptografada);

            Repositorio.Alterar(usuario);

            return new GenericCommandResult(false, "Senha alterada com sucesso!", null);
        }
    }
}