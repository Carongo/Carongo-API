using Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Commands.InstituicaoRequests
{
    public class AlterarInstituicaoCommand : Notifiable<Notification>, ICommand
    {
        public Guid IdInstituicao { get; set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public AlterarInstituicaoCommand(string nome, string descricao)
        {
           Nome = nome.Trim();
           Descricao = descricao.Trim();
        }


        public void Validar()
        {
            AddNotifications(new Contract<AlterarInstituicaoCommand>()
                 .Requires()
                 .IsTrue((Nome.Length > 3) && (Nome.Length < 255), "Nome", "Nome inválido!")
                 .IsTrue((Descricao.Length > 10) && (Descricao.Length < 512), "Descricao", "Descricao inválida!"));
        }
    }
}
