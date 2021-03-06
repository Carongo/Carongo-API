using Comum.Entidades;
using Comum.Enum;
using System;

namespace Dominio.Entidades
{
    public class UsuarioInstituicao : Entidade
    {
        public Guid IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }
        public Guid IdInstituicao { get; private set; }
        public Instituicao Instituicao { get; private set; }
        public EnTipoUsuario Tipo { get; private set; }

        public UsuarioInstituicao()
        {

        }

        public UsuarioInstituicao(Usuario usuario, Instituicao instituicao, EnTipoUsuario tipo)
        {
            Usuario = usuario;
            Instituicao = instituicao;
            Tipo = tipo;
        }
    }
}