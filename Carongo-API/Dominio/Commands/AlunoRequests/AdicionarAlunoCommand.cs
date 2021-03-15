using Comum.Commands;
using Dominio.Entidades;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Dominio.Commands.AlunoRequests
{
    public class AdicionarAlunoCommand : Notifiable<Notification>, ICommand
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string UrlFoto { get; private set; }
        public string CPF { get; private set; }
        public Guid IdTurma { get; private set; }
        public Turma Turma { get; private set; }

        public AdicionarAlunoCommand(string nome, string email, DateTime dataNascimento, string urlFoto, string cPF)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            UrlFoto = urlFoto;
            CPF = cPF;
        }

        public void Validar()
        {
            AddNotifications(new Contract<AdicionarAlunoCommand>()
                .Requires().IsNotNullOrEmpty(Nome, "Nome", "Digite o nome do aluno").IsNotNullOrEmpty(Email, "Email", "Informe o email do aluno")
                .IsNotNullOrEmpty(CPF, "CPF", "Digite o CPF do aluno")
                .IsNotNullOrEmpty(UrlFoto, "Imagem", "Envie a foto do aluno")
            );
        }
    }
}
