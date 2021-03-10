namespace Comum.Queries
{
    public class GenericQueryResult : IQueryResult
    {
        public bool Sucesso { get; private set; }
        public string Mensagem { get; private set; }
        public object Dados { get; private set; }

        public GenericQueryResult(bool sucesso, string mensagem, object dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }
    }
}