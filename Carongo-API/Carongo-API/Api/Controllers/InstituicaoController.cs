using Comum.Commands;
using Dominio.Commands.InstituicaoRequests;
using Dominio.Handlers.Commands.Instituicoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Api.Controllers
{
    [Route("instituicao")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        [HttpPost("criar-instituicao")]
        [Authorize]
        public ICommandResult CriarInstituicao(CriarInstituicaoCommand command, [FromServices] CriarInstituicaoCommandHandler handler)
        {
            command.IdUsuario = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return (GenericCommandResult) handler.Handle(command);
        }

        [HttpPut("entrar-na-instituicao")]
        [Authorize]
        public ICommandResult EntrarNaInstituicao(EntrarNaInstituicaoCommand command, [FromServices] EntrarNaInstituicaoCommandHandler handler)
        {
            command.IdUsuario = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return (GenericCommandResult) handler.Handle(command);
        }

        [HttpPut("adicionar-administrador")]
        [Authorize]
        public ICommandResult AdicionarAdministrador(AdicionarAdministradorCommand command, [FromServices] AdicionarAdministradorCommandHandler handler)
        {
            command.IdUsuario = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut("sair-da-instituicao")]
        [Authorize]
        public ICommandResult SairDaInstituicao(SairDaInstituicaoCommand command, [FromServices] SairDaInstituicaoCommandHandler handler)
        {
            command.IdUsuario = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut("adicionar-turma")]
        [Authorize]
        public ICommandResult AdicionarTurma(AdicionarTurmaCommand command, [FromServices] AdicionarTurmaCommandHandler handler)
        {
            return (GenericCommandResult) handler.Handle(command);
        }
    }
}