using Comum.Commands;
using Flunt.Notifications;
using System;

namespace Dominio.Commands.InstituicaoRequests
{
    public class DeletarInstituicaoCommand : Notifiable<Notification>, ICommand
    {
        public Guid IdInstituicao { get; set; }
        public void Validar(){}
    }
}