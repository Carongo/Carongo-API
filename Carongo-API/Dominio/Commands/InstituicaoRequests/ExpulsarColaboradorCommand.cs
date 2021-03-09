using Comum.Commands;
using Flunt.Notifications;
using System;

namespace Dominio.Commands.InstituicaoRequests
{
    public class ExpulsarColaboradorCommand : ICommand
    {
        public Guid IdInstituicao { get; set; }
        public Guid IdUsuarioInstituicao { get; set; }

        public void Validar(){}
    }
}