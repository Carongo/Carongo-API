using Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Dominio.Commands.InstituicaoRequests
{
    public class EntrarNaInstituicaoCommand : Notifiable<Notification>, ICommand
    {
        public Guid IdUsuario { get; set; }
        public string Codigo { get; set; }

        public EntrarNaInstituicaoCommand(string codigo)
        {
            Codigo = codigo.Trim().ToLower();
        }

        public void Validar()
        {
            AddNotifications(new Contract<EntrarNaInstituicaoCommand>()
                .Requires()
                .IsTrue(Codigo.Length == 7, "Codigo", "Código inválido!")
            );
        }
    }
}