using Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Dominio.Commands.UsuarioRequests
{
    public class LogarCommand : Notifiable<Notification>, ICommand
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public LogarCommand(string email, string senha)
        {
            Email = email.Trim().ToLower();
            Senha = senha.Trim();
        }

        public void Validar()
        {
            AddNotifications(new Contract<LogarCommand>()
                .Requires()
                .IsEmail(Email, "Email", "Email inválido!")
                .IsTrue((Senha.Length > 4) && (Senha.Length < 21), "Senha", "A senha deve ter de 6 a 20 caracteres!")
            );
        }
    }
}