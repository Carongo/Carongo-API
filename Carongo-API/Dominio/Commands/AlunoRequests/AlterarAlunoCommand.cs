using Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Dominio.Commands.AlunoRequests
{
    public class AlterarAlunoCommand : Notifiable<Notification>, ICommand
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string UrlFoto { get; set; }
        public string CPF { get; set; }
        public Guid IdAluno { get; set; }

        public AlterarAlunoCommand(string nome, string email, string urlFoto, string cpf)
        {
            Nome = nome.Trim();
            Email = email.Trim().ToLower();
            UrlFoto = urlFoto.Trim();
            CPF = cpf.Trim();
        }

        public void Validar()
        {
            AddNotifications(new Contract<AlterarAlunoCommand>()
                .Requires()
                .IsTrue((Nome.Length > 2) && (Nome.Length < 41), "Nome", "O nome do aluno deve ter de 3 à 40 caracteres!")
                .IsEmail(Email, "Email", "Email inválido!")
                .IsNotNullOrEmpty(DataNascimento.ToString(), "DataNascimento", "Data de nascimento inválida!")
                .IsTrue(CPF.Length == 11, "CPF", "CPF inválido!")
                .IsNotNullOrEmpty(IdAluno.ToString(), "IdAluno", "Id do aluno inválido!")
            );
        }
    }
}
