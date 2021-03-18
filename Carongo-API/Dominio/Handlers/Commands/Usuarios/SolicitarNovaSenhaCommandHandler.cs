using Comum.Commands;
using Comum.Handlers;
using Comum.Utils;
using Dominio.Commands.UsuarioRequests;
using Dominio.Repositorios;

namespace Dominio.Handlers.Commands.Usuarios
{
    public class SolicitarNovaSenhaCommandHandler : IHandlerCommand<SolicitarNovaSenhaCommand>
    {
        private IUsuarioRepositorio Repositorio { get; set; }

        public SolicitarNovaSenhaCommandHandler(IUsuarioRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public ICommandResult Handle(SolicitarNovaSenhaCommand command)
        {
            command.Validar();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos!", command.Notifications);

            var usuario = Repositorio.Buscar(command.Email);

            if (usuario == null)
                return new GenericCommandResult(false, "Não existe nenhum usuário cadastrado com o email informado!", command.Email);

            string token = JWT.Gerar(usuario.Nome, usuario.Email, usuario.Id, 5);

            string link = "http://localhost:3000/esqueci-minha-senha/redefinir-senha/" + token;

            Email.MandarEmail(usuario.Email, $"Olá, {usuario.Nome}!", $"<p>Você solicitou um link para redefinir sua senha? Se não foi você, apenas ignore este email. Se foi você, clique no botão abaixo para ser redirecionado para uma página onde você poderá redefinir sua senha. O link estará disponível por apenas 5 minutos.</p><br><a href='${link}'><button>Ir!</button></a><a>{link}</a>");

            return new GenericCommandResult(true, "Um email com mais instruções de redefinição de senha foi mandado para o endereço informado. Caso demore mais de 2 minutos, verifique a caixa de spam e a caixa de promoções. Se não estiver, solicite novamente.", null);
        }
    }
}