using Comum.Commands;
using Dominio.Commands.AlunoRequests;
using Dominio.Handlers.Commands.Alunos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("aluno")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        [HttpPut("alterar-aluno")]
        [Authorize]
        public ICommandResult AlterarAluno(AlterarAlunoCommand command, [FromServices] AlterarAlunoCommandHandler handler)
        {
            return (GenericCommandResult) handler.Handle(command);
        }

        [HttpDelete("deletar-aluno")]
        [Authorize]
        public ICommandResult DeletarAluno(DeletarAlunoCommand command, [FromServices] DeletarAlunoCommandHandler handler)
        {
            return (GenericCommandResult) handler.Handle(command);
        }
    }
}