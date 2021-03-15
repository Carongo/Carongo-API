using Comum.Queries;
using System;

namespace Dominio.Queries.InstituicaoRequests
{
    public class ListarPessoasDaInstituicaoQuery : IQuery
    {
        public Guid IdInstituicao { get; set; }

        public void Validar(){}
    }
}