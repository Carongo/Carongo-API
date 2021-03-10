using Comum.Commands;
using Comum.Enum;
using Comum.Handlers;
using Dominio.Commands.InstituicaoRequests;
using Dominio.Commands.InstituicaoResponses;
using Dominio.Entidades;
using Dominio.Repositorios;
using System;

namespace Dominio.Handlers.Commands.Instituicoes
{
    public class CriarInstituicaoCommandHandler : IHandlerCommand<CriarInstituicaoCommand>
    {
        private IInstituicaoRepositorio Repositorio { get; set; }

        public CriarInstituicaoCommandHandler(IInstituicaoRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public ICommandResult Handle(CriarInstituicaoCommand command)
        {
            command.Validar();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos!", command.Notifications);

            string codigo;

            do
            {
                codigo = GerarCodigo();
            } while (Repositorio.Buscar(codigo)!=null);

            var instituicao = new Instituicao(command.Nome, command.Descricao, codigo);

            var usuarioInstituicao = new UsuarioInstituicao(command.IdUsuario, instituicao.Id, EnTipoUsuario.Administrador);

            instituicao.UsuariosInstituicoes.Add(usuarioInstituicao);

            Repositorio.Adicionar(instituicao);

            var result = new InstituicaoGenericCommandResult(instituicao.Nome, instituicao.Descricao, instituicao.Codigo);

            return new GenericCommandResult(true, "Instituição criada com sucesso!", result);
        }

        public static string GerarCodigo()
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyz123456789";
            string codigo = "";

            Random random = new Random();

            for (int c = 0; c < 6; c++)
            {
                codigo += caracteres.Substring(random.Next(0, caracteres.Length - 1), 1);
                if (c == 2)
                    codigo += "-";
            }

            return codigo;
        }
    }
}