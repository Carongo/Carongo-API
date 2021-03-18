using Comum.Queries;
using System;

namespace Dominio.Queries.TurmaRequests
{
    public class ListarDetalhesTurmaQuery : IQuery
    {
        public Guid IdTurma { get; set; }

        public void Validar(){}
    }
}