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

        public void Alterar(string nome, string email)
        {
            if (nome != Nome)
                Nome = nome;

            if (email != Email)
                Email = email;
        }

        public void AlterarSenha(string senha)
        {
            Senha = senha;
        }
    }
}