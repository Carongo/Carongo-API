using Comum.Entidades;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public List<UsuarioInstituicao> UsuariosInstituicoes { get; }

        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            UsuariosInstituicoes = new List<UsuarioInstituicao>();
        }

        public void Alterar(string senha, string nome = null, string email = null)
        {
            if (senha != Senha)
                Senha = senha;

            if ((nome != Nome) && (nome != null))
                Nome = nome;

            if ((email != Email) && (email != null))
                Email = email;
        }
    }
}