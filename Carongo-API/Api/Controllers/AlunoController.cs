using Comum.Commands;
using Comum.Queries;
using Dominio.Commands.AlunoRequests;
using Dominio.Handlers.Commands.Alunos;
using Dominio.Handlers.Queries.Alunos;
using Dominio.Queries.AlunoRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Route("aluno")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        [HttpGet("detalhes/{id}")]
        [Authorize]
        public IQueryResult DetalhesAluno([FromServices] ListarAlunoPorIdQueryHandler handler, Guid id)
        {
            var query = new ListarAlunoPorIdQuery();
            query.IdAluno = id;
            return (GenericQueryResult) handler.Handle(query);
        }

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