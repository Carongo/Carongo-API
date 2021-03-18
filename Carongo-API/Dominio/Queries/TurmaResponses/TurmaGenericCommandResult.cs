namespace Dominio.Queries.TurmaResponses
{
    public class TurmaGenericCommandResult
    {
        public string Nome { get; set; }

        public TurmaGenericCommandResult(string nome)
        {
            Nome = nome;
        }
    }
}