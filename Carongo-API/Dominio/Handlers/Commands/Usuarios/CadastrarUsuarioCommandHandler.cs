using CodeTur.Comum.Utils;
using Comum.Commands;
using Comum.Handlers;
using Dominio.Commands.UsuarioRequests;
using Dominio.Commands.UsuarioResponses;
using Dominio.Entidades;
using Dominio.Repositorios;

namespace Dominio.Handlers.Commands.Usuarios
{
    public class CadastrarUsuarioCommandHandler : IHandlerCommand<CadastrarUsuarioCommand>
    {
        private IUsuarioRepositorio Repositorio { get; set; }

        public CadastrarUsuarioCommandHandler(IUsuarioRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public ICommandResult Handle(CadastrarUsuarioCommand command)
        {
            command.Validar();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos!", command.Notifications);

            bool usuarioExiste = Repositorio.Buscar(command.Email) != null;
            if (usuarioExiste)
                return new GenericCommandResult(false, "Já existe um usuário cadastrado com o email informado!", command.Email);

            string senhaCriptografada = Senha.Criptografar(command.Senha);
            var usuario = new Usuario(command.Nome, command.Email, senhaCriptografada);

            usuario = Repositorio.Adicionar(usuario);

            if (usuario != null)
                Email.MandarEmail(usuario.Email, $"Olá, {usuario.Nome}! Seja muito bem-vindo(a) ao Carongo!", "<p>No nosso sistema você pode criar ou entrar em instituições, gerenciá-las e, finalmente, criar um carômetro de seus alunos de cada instituição. Estamos sempre trabalhando em atualizações para incluir novas funcionalidades e aumentar a performance do sistema. Aproveite!</p>");

            var resultado = new UsuarioGenericCommandResult(usuario.Id, usuario.DataCriacao, usuario.Nome, usuario.Email);

            return new GenericCommandResult(true, "Usuário cadastrado com sucesso!", resultado);
        }
    }
}