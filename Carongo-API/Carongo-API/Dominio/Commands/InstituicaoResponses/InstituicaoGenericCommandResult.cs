namespace Dominio.Commands.InstituicaoResponses
{
    public class InstituicaoGenericCommandResult
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }

        public InstituicaoGenericCommandResult(string nome, string descricao, string codigo)
        {
            Nome = nome;
            Descricao = descricao;
            Codigo = codigo;
        }
    }
}