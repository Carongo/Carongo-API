using Comum.Commands;
using Flunt.Notifications;
using System;

namespace Dominio.Commands.InstituicaoRequests
{
    public class SairDaInstituicaoCommand : Notifiable<Notification>, ICommand
    {
        public Guid IdInstituicao { get; set; }
        public Guid IdUsuario { get; set; }

        public SairDaInstituicaoCommand(Guid idInstituicao)
        {
            IdInstituicao = idInstituicao;
        }

        public void Validar(){}
    }
}