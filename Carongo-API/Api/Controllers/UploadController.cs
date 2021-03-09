using Comum.Commands;
using Comum.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("upload")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost("imagem")]
        [Authorize]
        public ICommandResult Imagem([FromForm] IFormFile arquivo)
        {
            if (arquivo == null)
                return new GenericCommandResult(false, "Envie um arquivo!", null);

            if (arquivo.ContentType != "image/*")
                return new GenericCommandResult(false, "É necessário que o arquivo enviado seja uma imagem!", null);

            var urlImagem = Upload.Imagem(arquivo);

            return new GenericCommandResult(true, "Upload concluído com sucesso!", urlImagem);
        }
    }
}