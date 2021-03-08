using Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System.IdentityModel.Tokens.Jwt;

namespace Dominio.Commands.UsuarioRequests
{
    public class RedefinirSenhaCommand : Notifiable<Notification>, ICommand
    {
        public JwtSecurityToken Token { get; set; }
        public string Senha { get; set; }

        public RedefinirSenhaCommand(string token, string senha)
        {
            Token = new JwtSecurityTokenHandler().ReadJwtToken(token);
            Senha = senha.Trim();
        }

        public void Validar()
        {
            AddNotifications(new Contract<RedefinirSenhaCommand>()
                .Requires()
                .IsTrue((Senha.Length > 5) && (Senha.Length < 20), "Senha", "A senha deve ter de 6 a 20 caracteres!")
            );
        }
    }
}