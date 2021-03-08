using Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Dominio.Commands.InstituicaoRequests
{
    public class AdicionarAdministradorCommand : Notifiable<Notification>, ICommand
    {
        public string Email { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdInstituicao { get; set; }

        public AdicionarAdministradorCommand(string email, Guid idInstituicao)
        {
            Email = email.Trim().ToLower();
            IdInstituicao = idInstituicao;
        }

        public void Validar()
        {
            AddNotifications(new Contract<CriarInstituicaoCommand>()
                .Requires()
                .IsEmail(Email, "Email", "Email inválido!")
            );
        }
    }
}