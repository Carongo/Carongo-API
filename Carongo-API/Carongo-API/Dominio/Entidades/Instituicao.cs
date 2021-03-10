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
        public List<UsuarioInstituicao> UsuariosInstituicoes { get; }

        public Instituicao(string nome, string descricao, string codigo)
        {
            Nome = nome;
            Descricao = descricao;
            Codigo = codigo;
            Turmas = new List<Turma>();
            UsuariosInstituicoes = new List<UsuarioInstituicao>();
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