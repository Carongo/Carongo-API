using Comum.Commands;
using Flunt.Notifications;
using System;

namespace Dominio.Commands.UsuarioRequests
{
    public class DeletarContaCommand : Notifiable<Notification>, ICommand
    {
        public Guid IdUsuario { get; set; }

        public void Validar(){}
    }
}