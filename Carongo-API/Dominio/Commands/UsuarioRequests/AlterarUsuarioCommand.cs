using Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Dominio.Commands.UsuarioRequests
{
    public class AlterarUsuarioCommand : Notifiable<Notification>, ICommand
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public AlterarUsuarioCommand(string nome, string email)
        {
            Nome = nome.Trim();
            Email = email.Trim().ToLower();
        }

        public void Validar()
        {
            AddNotifications(new Contract<AlterarUsuarioCommand>()
                .Requires()
                .IsTrue((Nome.Length > 3) && (Nome.Length < 40), "Nome", "O nome deve ter de 3 a 40 caracteres!")
                .IsEmail(Email, "Email", "Email inválido!")
            );
        }
    }
}