﻿using Comum.Commands;
using Comum.Queries;
using Dominio.Commands.InstituicaoRequests;
using Dominio.Handlers.Commands.Instituicoes;
using Dominio.Handlers.Queries.Instituicoes;
using Dominio.Queries.InstituicaoRequests;
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
        [HttpGet("listar-minhas-instituicoes/{nome?}")]
        [Authorize]
        public IQueryResult ListarMinhasInstituicoes([FromServices] ListarMinhasInstituicoesQueryHandler handler, string nome = null)
        {
            var query = new ListarMinhasInstituicoesQuery();
            query.Nome = nome;
            query.IdUsuario = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return (GenericQueryResult) handler.Handle(query);
        }

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

        [HttpDelete("expulsar-colaborador")]
        [Authorize]
        public ICommandResult ExpulsarColaborador(ExpulsarColaboradorCommand command, [FromServices] ExpulsarColaboradorCommandHandler handler)
        {
            return (GenericCommandResult) handler.Handle(command);
        }
    }
}