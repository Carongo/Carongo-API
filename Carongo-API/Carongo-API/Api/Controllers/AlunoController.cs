using Comum.Commands;
using Dominio.Commands.Aluno;
using Dominio.Handlers.Commands.Alunos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class AlunoController : ControllerBase
    {
        [HttpPost("cadastrarAluno")]
        [Authorize]
        public ICommandResult CriarInstituicao(AdicionarAlunoCommand command, [FromServices] AdicionarAlunoCommandHandler handler)
        {
            
            return (GenericCommandResult)handler.Handle(command);
        }
        
    }
}
