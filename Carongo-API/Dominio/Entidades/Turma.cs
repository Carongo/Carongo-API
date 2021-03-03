using Comum.Entidades;
using System;

namespace Dominio.Entidades
{
    public class Turma : Entidade
    {
        public string Nome { get; private set; }
        public string Disciplina { get; private set; }
        public string Descricao { get; private set; }
        public string Codigo { get; private set; }

        public Turma(string nome, string disciplina, string descricao)
        {
            Nome = nome;
            Disciplina = disciplina;
            Descricao = descricao;
            GerarCodigo();
        }

        public void Alterar(string nome, string disciplina, string descricao)
        {
            if (nome != Nome)
                Nome = nome;

            if (disciplina != Disciplina)
                Disciplina = disciplina;

            if (descricao != Descricao)
                Descricao = descricao;
        }

        private void GerarCodigo()
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyz123456789";

            Random random = new Random();

            for (int c = 0; c < 8; c++)
            {
                Codigo += caracteres.Substring(random.Next(0, caracteres.Length - 1), 1);
            }

            //TODO: Verificar se código já existe utlizando repositório de turmas.
        }
    }
}