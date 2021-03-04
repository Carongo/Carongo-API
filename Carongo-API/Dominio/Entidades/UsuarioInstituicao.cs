using Comum.Entidades;
using System;

namespace Dominio.Entidades
{
    public class UsuarioInstituicao : Entidade
    {
        public Guid IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }
        public Guid IdInstituicao { get; private set; }
        public Instituicao Instituicao { get; private set; }
    }
}