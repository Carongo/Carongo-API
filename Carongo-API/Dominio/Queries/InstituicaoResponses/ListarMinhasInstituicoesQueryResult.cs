using System;

namespace Dominio.Queries.InstituicaoResponses
{
    public class ListarMinhasInstituicoesQueryResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string TipoUsuario { get; set; }

        public ListarMinhasInstituicoesQueryResult(Guid id, string nome, string descricao, string tipoUsuario)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            TipoUsuario = tipoUsuario;
        }
    }
}