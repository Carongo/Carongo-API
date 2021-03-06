﻿using Comum.Commands;
using Comum.Handlers;
using Dominio.Commands.UsuarioRequests;
using Dominio.Commands.UsuarioResponses;
using Dominio.Repositorios;

namespace Dominio.Handlers.Commands.Usuarios
{
    public class AlterarUsuarioCommandHandler : IHandlerCommand<AlterarUsuarioCommand>
    {
        private IUsuarioRepositorio Repositorio { get; set; }

        public AlterarUsuarioCommandHandler(IUsuarioRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public ICommandResult Handle(AlterarUsuarioCommand command)
        {
            command.Validar();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos!", command.Notifications);

            var usuario = Repositorio.Buscar(command.Email);

            if (usuario == null)
                return new GenericCommandResult(false, "Não existe nenhum usuário cadastrado com o email informado!", command.Email);

            if(usuario.Id != command.IdUsuario)
                return new GenericCommandResult(false, "Você não tem permissão para alterar esse usuário!", null);

            usuario.Alterar(command.Nome, command.Email);

            usuario = Repositorio.Alterar(usuario);

            var result = new UsuarioGenericCommandResult(usuario.DataCriacao, usuario.Nome, usuario.Email);

            return new GenericCommandResult(true, "Usuário alterado com sucesso!", result);
        }
    }
}