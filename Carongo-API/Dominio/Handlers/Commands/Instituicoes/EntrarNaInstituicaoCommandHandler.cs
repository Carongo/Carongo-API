using Comum.Commands;
using Comum.Enum;
using Comum.Handlers;
using Dominio.Commands.InstituicaoRequests;
using Dominio.Entidades;
using Dominio.Repositorios;

namespace Dominio.Handlers.Commands.Instituicoes
{
    public class EntrarNaInstituicaoCommandHandler : IHandlerCommand<EntrarNaInstituicaoCommand>
    {
        private IInstituicaoRepositorio Repositorio { get; set; }

        public EntrarNaInstituicaoCommandHandler(IInstituicaoRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public ICommandResult Handle(EntrarNaInstituicaoCommand command)
        {
            command.Validar();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos!", command.Notifications);

            var instituicao = Repositorio.Buscar(command.Codigo);

            if(instituicao==null)
                return new GenericCommandResult(false, "Não existe nenhuma instituição com o código informado!", command.Codigo);

            if(instituicao.UsuariosInstituicoes.Find(ui => ui.IdUsuario == command.IdUsuario) != null)
                return new GenericCommandResult(false, "Você já faz parte dessa instituição!", command.Codigo);

            var usuarioInstituicao = new UsuarioInstituicao(command.IdUsuario, instituicao.Id, EnTipoUsuario.Colaborador);

            Repositorio.AdicionarUsuario(usuarioInstituicao);

            return new GenericCommandResult(true, $"Bem vindo à {instituicao.Nome}!", null);
        }
    }
}