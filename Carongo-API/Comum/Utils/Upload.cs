//using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace CodeTur.Comum.Utils
{
    public static class Upload
    {
        public static string Local(/*IFormFile file*/)
        {
            /*var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);

            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads\Imagens", nomeArquivo);

            using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

            file.CopyTo(streamImagem);*/

            return "http://192.168.1.105:5000/Uploads/Imagens/" /*+ nomeArquivo*/;
        }
    }
}