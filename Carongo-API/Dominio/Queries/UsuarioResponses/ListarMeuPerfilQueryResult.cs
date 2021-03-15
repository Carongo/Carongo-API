using System;

namespace Dominio.Queries.UsuarioResponses
{
    public class ListarMeuPerfilQueryResult
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public ListarMeuPerfilQueryResult(Guid idUsuario, string nome, string email)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Email = email;
        }
    }
}