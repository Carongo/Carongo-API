using Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Dominio.Commands.UsuarioRequests
{
    public class AlterarSenhaCommand : Notifiable<Notification>, ICommand
    {
        public Guid IdUsuario { get; set; }
        public string SenhaAtual { get; set; }
        public string SenhaNova { get; set; }

        public AlterarSenhaCommand(string senhaAtual, string senhaNova)
        {
            SenhaAtual = senhaAtual.Trim();
            SenhaNova = senhaNova.Trim();
        }

        public void Validar()
        {
            AddNotifications(new Contract<AlterarSenhaCommand>()
                .Requires()
                .IsTrue((SenhaAtual.Length > 5) && (SenhaAtual.Length < 20), "Senha Atual", "Senha atual inválida!")
                .IsTrue((SenhaNova.Length > 5) && (SenhaNova.Length < 20), "Senha Nova", "A nova senha deve ter de 6 a 20 caracteres!")
            );
        }
    }
}