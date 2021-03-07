using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Comum.Utils
{
    public static class Email
    {
        public static async Task MandarEmail(string destinatario, string assunto, string corpo)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

            var client = new SendGridClient(apiKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("daniel.amaral720@gmail.com", "Carongo"),
                Subject = assunto,
                HtmlContent = $"{corpo}"
            };

            msg.AddTo(new EmailAddress(destinatario));

            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}