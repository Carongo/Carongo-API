using Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Dominio.Commands.UsuarioRequests
{
    public class AlterarUsuarioCommand : Notifiable<Notification>, ICommand
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public AlterarUsuarioCommand(string nome, string email, string senha)
        {
            Nome = nome.Trim();
            Email = email.Trim().ToLower();
            Senha = senha.Trim();
        }

        public void Validar()
        {
            AddNotifications(new Contract<AlterarUsuarioCommand>()
                .Requires()
                .IsTrue((Nome.Length > 3) && (Nome.Length < 40), "Nome", "O nome deve ter de 3 a 40 caracteres!")
                .IsEmail(Email, "Email", "Email inválido!")
                .IsTrue((Senha.Length > 5) && (Senha.Length < 20), "Senha", "A senha deve ter de 6 a 20 caracteres!")
            );
        }
    }
}