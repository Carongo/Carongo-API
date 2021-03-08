using Comum.Commands;
using Comum.Utils;
using Dominio.Commands.UsuarioRequests;
using Dominio.Entidades;
using Dominio.Handlers.Commands.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Api.Controllers
{
    [Route("conta")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost("cadastrar-se")]
        public ICommandResult Cadastrar(CadastrarUsuarioCommand command, [FromServices] CadastrarUsuarioCommandHandler handler)
        {
            return (GenericCommandResult) handler.Handle(command);
        }

        [HttpPost("entrar")]
        public ICommandResult Entrar(LogarCommand command, [FromServices] LogarCommandHandler handler)
        {
            var resultado = (GenericCommandResult) handler.Handle(command);

            if (resultado.Sucesso)
            {
                var usuario = (Usuario) resultado.Dados;
                var token = JWT.Gerar(usuario.Nome, usuario.Email, usuario.Id, 120);

                return new GenericCommandResult(resultado.Sucesso, resultado.Mensagem, token);
            }

            return resultado;
        }

        [HttpPost("solicitar-nova-senha")]
        public ICommandResult SolicitarNovaSenha(SolicitarNovaSenhaCommand command, [FromServices] SolicitarNovaSenhaCommandHandler handler)
        {
            return (GenericCommandResult) handler.Handle(command);
        }

        [HttpPut("alterar-usuario")]
        [Authorize]
        public ICommandResult AlterarUsuario(AlterarUsuarioCommand command, [FromServices] AlterarUsuarioCommandHandler handler)
        {
            command.IdUsuario = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return (GenericCommandResult) handler.Handle(command);
        }

        [HttpPut("alterar-senha")]
        [Authorize]
        public ICommandResult AlterarSenha(AlterarSenhaCommand command, [FromServices] AlterarSenhaCommandHandler handler)
        {
            command.IdUsuario = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return (GenericCommandResult) handler.Handle(command);
        }

        [HttpPut("redefinir-senha")]
        public ICommandResult RedefinirSenha(RedefinirSenhaCommand command, [FromServices] RedefinirSenhaCommandHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut("deletar-conta")]
        [Authorize]
        public ICommandResult DeletarConta(DeletarContaCommand command, [FromServices] DeletarContaCommandHandler handler)
        {
            command.IdUsuario = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return (GenericCommandResult) handler.Handle(command);
        }
    }
}