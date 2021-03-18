using Comum.Commands;
using Comum.Queries;
using Dominio.Commands.TurmaRequests;
using Dominio.Handlers.Commands.Alunos;
using Dominio.Handlers.Commands.Turmas;
using Dominio.Handlers.Queries.Turmas;
using Dominio.Queries.TurmaRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Route("turma")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        [HttpGet("detalhes/{id}")]
        [Authorize]
        public IQueryResult DetalhesTurma([FromServices] ListarDetalhesTurmaQueryHandler handler, Guid id)
        {
            var query = new ListarDetalhesTurmaQuery();
            query.IdTurma = id;
            return (GenericQueryResult)handler.Handle(query);
        }

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