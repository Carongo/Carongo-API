using Comum.Queries;
using System;

namespace Dominio.Queries.InstituicaoRequests
{
    public class ListarMinhasInstituicoesQuery : IQuery
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; } = null;

        public ListarMinhasInstituicoesQuery(string nome = null)
        {
            if(nome!=null)
                Nome = nome.Trim().ToLower();
        }

        public void Validar(){}
    }
}