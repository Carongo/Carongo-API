using Comum.Entidades;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Instituicao : Entidade
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Codigo { get; private set; }
        public List<Turma> Turmas { get; }
        public List<UsuarioInstituicao> UsuarioInstituicao { get; }

        public Instituicao(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public void Alterar(string nome, string descricao)
        {
            if (nome != Nome)
                Nome = nome;

            if (descricao != Descricao)
                Descricao = descricao;
        }
    }
}