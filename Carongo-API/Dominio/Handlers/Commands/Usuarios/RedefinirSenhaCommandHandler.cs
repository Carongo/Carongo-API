using Comum.Commands;
using Comum.Handlers;
using Comum.Utils;
using Dominio.Commands.UsuarioRequests;
using Dominio.Repositorios;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Dominio.Handlers.Commands.Usuarios
{
    public class RedefinirSenhaCommandHandler : IHandlerCommand<RedefinirSenhaCommand>
    {
        private IUsuarioRepositorio Repositorio { get; set; }

        public RedefinirSenhaCommandHandler(IUsuarioRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public ICommandResult Handle(RedefinirSenhaCommand command)
        {
            command.Validar();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos!", command.Notifications);

            var expirou = (command.Token.ValidTo.CompareTo(DateTime.Now)) <= 0;
            if(expirou)
                return new GenericCommandResult(false, "O link expirou. Solicite outro. Lembre-se que após a solicitação do link para redefinir sua senha, você tem apenas 5 minutos, por questões de segurança!", null);

            var idUsuario = Guid.Parse(command.Token.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

            var usuario = Repositorio.Buscar(idUsuario);

            if(usuario == null)
                return new GenericCommandResult(false, "Usuário inexistente! Esse erro geralmente acontece quando a url dessa página é modificada e se torna diferente da url mandada no seu email. Para corrigir, solicite outro link.", null);

            var senhaCriptografada = Senha.Criptografar(command.Senha);

            usuario.AlterarSenha(senhaCriptografada);

            Repositorio.Alterar(usuario);

            return new GenericCommandResult(true, "Senha redefinida com sucesso!", null);
        }
    }
}