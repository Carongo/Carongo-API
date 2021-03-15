using Comum.Queries;
using System;

namespace Dominio.Queries.UsuarioRequests
{
    public class ListarMeuPerfilQuery : IQuery
    {
        public Guid IdUsuario { get; set; }

        public void Validar(){}
    }
}