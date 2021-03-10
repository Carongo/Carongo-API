using Comum.Commands;
using Comum.Enum;
using Comum.Handlers;
using Dominio.Commands.InstituicaoRequests;
using Dominio.Entidades;
using Dominio.Repositorios;

namespace Dominio.Handlers.Commands.Instituicoes
{
    public class AdicionarAdministradorCommandHandler : IHandlerCommand<AdicionarAdministradorCommand>
    {
        private IInstituicaoRepositorio InstituicaoRepositorio { get; set; }
        private IUsuarioRepositorio UsuarioRepositorio { get; set; }

        public AdicionarAdministradorCommandHandler(IInstituicaoRepositorio instituicaoRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            InstituicaoRepositorio = instituicaoRepositorio;
            UsuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handle(AdicionarAdministradorCommand command)
        {
            command.Validar();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos!", command.Notifications);

            var instituicao = InstituicaoRepositorio.Buscar(command.IdInstituicao);

            var naoEhPermitido = instituicao.UsuariosInstituicoes.Find(ui => ui.IdUsuario == command.IdUsuario).Tipo == EnTipoUsuario.Colaborador;

            if(naoEhPermitido)
                return new GenericCommandResult(false, "Você não tem permissão para adicionar administradores nessa instituição!", null);

            var novoAdministrador = UsuarioRepositorio.Buscar(command.Email);

            if (novoAdministrador == null)
                return new GenericCommandResult(false, "Não existe nenhum usuário cadastrado com o email informado!", command.Email);

            var usuarioInstituicao = instituicao.UsuariosInstituicoes.Find(ui => ui.IdUsuario == novoAdministrador.Id);

            if (usuarioInstituicao == null)
            {
                InstituicaoRepositorio.AdicionarUsuario(new UsuarioInstituicao(novoAdministrador.Id, instituicao.Id, EnTipoUsuario.Administrador));
                return new GenericCommandResult(false, "Administrador adicionado com sucesso!", null);
            }
            else if (usuarioInstituicao.Tipo == EnTipoUsuario.Administrador)
                return new GenericCommandResult(false, "O usuário informado já é um administrador da instituição!", command.Email);
            else
            {
                usuarioInstituicao.AlterarTipo(EnTipoUsuario.Administrador);
                InstituicaoRepositorio.AlterarUsuario(usuarioInstituicao);
                return new GenericCommandResult(false, "Colaborador atualizado para administrador com sucesso!", null);
            }
        }
    }
}