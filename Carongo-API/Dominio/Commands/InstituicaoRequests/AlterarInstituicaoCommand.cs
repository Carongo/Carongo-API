using Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Dominio.Commands.InstituicaoRequests
{
    public class AlterarInstituicaoCommand : Notifiable<Notification>, ICommand
    {
        public Guid IdInstituicao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public AlterarInstituicaoCommand(string nome, string descricao)
        {
           Nome = nome.Trim();
           Descricao = descricao.Trim();
        }

        public void Validar()
        {
            AddNotifications(new Contract<AlterarInstituicaoCommand>()
                 .Requires()
                 .IsTrue((Nome.Length > 2) && (Nome.Length < 41), "Nome", "O nome da instituição deve ter de 3 à 40 caracteres!")
                 .IsTrue((Descricao.Length > 4) && (Descricao.Length < 201), "Descricao", "A descrição da instituição deve ter de 5 à 200 caracteres!")
            );
        }
    }
}