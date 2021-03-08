using Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Dominio.Commands.UsuarioRequests
{
    public class SolicitarNovaSenhaCommand : Notifiable<Notification>, ICommand
    {
        public string Email { get; set; }

        public SolicitarNovaSenhaCommand(string email)
        {
            Email = email.Trim().ToLower();
        }

        public void Validar()
        {
            AddNotifications(new Contract<SolicitarNovaSenhaCommand>()
                .Requires()
                .IsEmail(Email, "Email", "Email inválido!")
            );
        }
    }
}