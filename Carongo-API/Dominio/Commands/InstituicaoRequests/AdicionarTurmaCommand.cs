using Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Dominio.Commands.InstituicaoRequests
{
    public class AdicionarTurmaCommand : Notifiable<Notification>, ICommand
    {
        public string Nome { get; set; }
        public Guid IdInstituicao { get; set; }

        public AdicionarTurmaCommand(string nome)
        {
            Nome = nome.Trim();
        }

        public void Validar()
        {
            AddNotifications(new Contract<CriarInstituicaoCommand>()
                .Requires()
                .IsTrue((Nome.Length > 2) && (Nome.Length < 31), "Nome", "O nome da turma deve ter de 3 à 30 caracteres!")
            );
        }
    }
}