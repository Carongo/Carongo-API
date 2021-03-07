using Comum.Commands;
using Dominio.Commands.UsuarioRequests;
using Dominio.Entidades;
using Dominio.Handlers.Commands.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers
{
    [Route("account")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost("signup")]
        public ICommandResult SignUp(CadastrarUsuarioCommand command, [FromServices] CadastrarUsuarioCommandHandler handler)
        {
            return (GenericCommandResult) handler.Handle(command);
        }

        [HttpPost("signin")]
        public ICommandResult SignIn(LogarCommand command, [FromServices] LogarCommandHandler handler)
        {
            var resultado = (GenericCommandResult) handler.Handle(command);

            if (resultado.Sucesso)
            {
                var token = GerarJSONWebToken((Usuario) resultado.Dados);

                return new GenericCommandResult(resultado.Sucesso, resultado.Mensagem, token);
            }

            return resultado;
        }

        [HttpPut("changeuser")]
        [Authorize]
        public ICommandResult ChangeUser(AlterarUsuarioCommand command, [FromServices] AlterarUsuarioCommandHandler handler)
        {
            return (GenericCommandResult) handler.Handle(command);
        }

        private string GerarJSONWebToken(Usuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Carongo-b71e507ae8f44b4396530166279942af"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("nome", usuario.Nome),
                new Claim("email", usuario.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString())
            };

            var token = new JwtSecurityToken
                (
                    "Carongo",
                    "Carongo",
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}