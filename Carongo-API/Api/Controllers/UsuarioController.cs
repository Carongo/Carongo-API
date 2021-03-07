using Comum.Commands;
using Dominio.Commands.UsuarioRequests;
using Dominio.Handlers.Commands.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("account")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost("signup")]
        public ICommandResult Post(CadastrarUsuarioCommand command, [FromServices] CadastrarUsuarioCommandHandler handler)
        {
            return (GenericCommandResult) handler.Handle(command);
        }
    }
}