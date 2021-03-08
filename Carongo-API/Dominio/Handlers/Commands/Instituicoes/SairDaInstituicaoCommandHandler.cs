using Comum.Commands;
using Comum.Enum;
using Comum.Handlers;
using Dominio.Commands.InstituicaoRequests;
using Dominio.Repositorios; 

namespace Dominio.Handlers.Commands.Instituicoes
{
    public class SairDaInstituicaoCommandHandler : IHandlerCommand<SairDaInstituicaoCommand>
    {
        private IInstituicaoRepositorio Repositorio { get; set; }

        public SairDaInstituicaoCommandHandler(IInstituicaoRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public ICommandResult Handle(SairDaInstituicaoCommand command)
        {
            var instituicao = Repositorio.Buscar(command.IdInstituicao);

            var usuarioInstituicao = instituicao.UsuariosInstituicoes.Find(ui => ui.IdUsuario == command.IdUsuario);
            var ehAdministrador = usuarioInstituicao.Tipo == EnTipoUsuario.Administrador;

            if (!ehAdministrador)
            {
                Repositorio.DeletarUsuario(usuarioInstituicao.Id);
                return new GenericCommandResult(true, "Você saiu da instituição com sucesso!", null);
            }

            var administradores = instituicao.UsuariosInstituicoes.FindAll(ui => ui.Tipo == EnTipoUsuario.Administrador).Count;
            var colaboradores = instituicao.UsuariosInstituicoes.FindAll(ui => ui.Tipo == EnTipoUsuario.Colaborador).Count;

            if (administradores > 1)
            {
                Repositorio.DeletarUsuario(usuarioInstituicao.Id);
                return new GenericCommandResult(true, "Você saiu da instituição com sucesso!", null);
            }
            else if(administradores==1 && colaboradores>0)
                return new GenericCommandResult(false, "Você não pode sair da instituição, pois ainda há colaboradores nela e você é o único administrador! Mas você pode deletar...", null);
            else
            {
                Repositorio.Deletar(instituicao.Id);
                return new GenericCommandResult(true, "Você saiu da instituição com sucesso, e como era o único membro dela, excluímos ela para você!", null);
            }
        }
    }
}