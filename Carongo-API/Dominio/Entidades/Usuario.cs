using Comum.Entidades;
using Comum.Enum;

namespace Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public EnTipoUsuario Tipo { get; private set; }

        public Usuario(string nome, string email, string senha, EnTipoUsuario tipo)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Tipo = tipo;
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