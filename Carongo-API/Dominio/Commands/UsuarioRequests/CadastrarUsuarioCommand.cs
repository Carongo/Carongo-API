﻿using Comum.Commands;
using Dominio.Entidades;
using Flunt.Notifications;
using Flunt.Validations;

namespace Dominio.Commands.UsuarioRequests
{
    public class CadastrarUsuarioCommand : Notifiable<Notification>, ICommand
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public CadastrarUsuarioCommand(string nome, string email, string senha)
        {
            Nome = nome.Trim();
            Email = email.Trim().ToLower();
            Senha = senha.Trim();
        }

        public void Validar()
        {
            AddNotifications(new Contract<CadastrarUsuarioCommand>()
                .Requires()
                .IsTrue((Nome.Length > 2) && (Nome.Length < 41), "Nome", "O nome deve ter de 3 a 40 caracteres!")
                .IsEmail(Email, "Email", "Email inválido!")
                .IsTrue((Senha.Length > 4) && (Senha.Length < 21), "Senha", "A senha deve ter de 6 a 20 caracteres!")
            );
        }
    }
}