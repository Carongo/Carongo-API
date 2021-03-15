using Comum.Commands;
using Dominio.Commands.TurmaRequests;
using Dominio.Handlers.Commands.Alunos;
using Dominio.Handlers.Commands.Turmas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace Api.Controllers
{
    [Route("turma")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        [HttpPost("adicionar-aluno")]
        [Authorize]
        public ICommandResult AdicionarAluno(AdicionarAlunoCommand command, [FromServices] AdicionarAlunoCommandHandler handler)
        {
            return (GenericCommandResult) handler.Handle(command);
        }

        [HttpPut("alterar-turma")]
        [Authorize]
        public ICommandResult AlterarTurma(AlterarTurmaCommand command, [FromServices] AlterarTurmaCommandHandler handler)
        {
            return (GenericCommandResult) handler.Handle(command);
        }

        [HttpDelete("deletar-turma")]
        [Authorize]
        public ICommandResult DeletarTurma(DeletarTurmaCommand command, [FromServices] DeletarTurmaCommandHandler handler)
        {
            return (GenericCommandResult) handler.Handle(command);
        }
    }
}