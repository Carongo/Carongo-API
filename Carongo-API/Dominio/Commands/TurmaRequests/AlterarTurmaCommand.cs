using Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Dominio.Commands.TurmaRequests
{
    public class AlterarTurmaCommand : Notifiable<Notification>, ICommand
    {
        public string Nome { get; set; }
        public Guid IdTurma { get; set; }

        public AlterarTurmaCommand(string nome)
        {
            Nome = nome.Trim();
        }

        public void Validar()
        {
            AddNotifications(new Contract<AlterarTurmaCommand>()
                .Requires()
                .IsTrue((Nome.Length > 2) && (Nome.Length < 31), "Nome", "O nome da turma deve ter de 3 à 30 caracteres!")
            );
        }
    }
}