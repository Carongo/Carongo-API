using Comum.Queries;
using System;

namespace Dominio.Queries.AlunoRequests
{
    public class ListarAlunoPorIdQuery : IQuery
    {
        public Guid IdAluno { get; set; }

        public void Validar(){}
    }
}