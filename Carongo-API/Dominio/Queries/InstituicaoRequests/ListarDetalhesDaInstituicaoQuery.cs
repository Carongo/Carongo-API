using Comum.Queries;
using System;

namespace Dominio.Queries.InstituicaoRequests
{
    public class ListarDetalhesDaInstituicaoQuery : IQuery
    {
        public Guid IdInstituicao { get; set; }
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; } = null;
        public string UrlImagem { get; set; } = null;

        public ListarDetalhesDaInstituicaoQuery(string nome = null, string urlImagem = null)
        {
            if(urlImagem != null)
            {
                UrlImagem = urlImagem.Trim();
                Nome = null;
            }

            if(nome != null)
            {
                UrlImagem = null;
                Nome = nome.Trim().ToLower();
            }
        }

        public void Validar(){}
    }
}