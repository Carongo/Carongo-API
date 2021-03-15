using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Comum.Utils
{
    public static class Upload
    {
        public static string Imagem(IFormFile imagem)
        {
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(imagem.FileName);

            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads\Imagens", nomeArquivo);

            using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

            imagem.CopyTo(streamImagem);

            return "http://localhost:5000/Uploads/Imagens/" + nomeArquivo;
        }
    }
}