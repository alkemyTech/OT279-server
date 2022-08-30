using Microsoft.Extensions.Configuration;
using OngProject.Core.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OngProject.Core.Helper
{
    public class SendGridHelper : ISendGridBusiness
    {
        private readonly IConfiguration _config;

        public SendGridHelper(IConfiguration configuration)
        {
            _config = configuration;
        }
        public async Task<bool> WelcomeEmail(string email)
        {
            var apiKey = _config["SendGrid:ApiKey"];
            var emailToSendGrid = _config["SendGrid:Email"];
            var welcomeTitle = "Bienvenido, Gracias por registrarse";
            var welcomeContent = "Gracias por sumarte";
            var subject = "Bienvenido";

            try
            {
                var client = new SendGridClient(apiKey);
                var from_email = new EmailAddress(emailToSendGrid, "Comision 279 Alkemy");
                var to_email = new EmailAddress("ezecaliguri@gmail.com", "Example User");
                var htmlContent = GetTemplate(welcomeTitle, welcomeContent);
                var msg = MailHelper.CreateSingleEmail(from_email, to_email, subject, "", htmlContent);
                await client.SendEmailAsync(msg).ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static string GetTemplate(string newTitle, string newContentPage)
        {
            try
            {
                var templateFile = Path.Combine(Directory.GetCurrentDirectory(), "Templates\\SendGridTemplate.html");
                StreamReader Sr = File.OpenText(templateFile);
                string textReader = Sr.ReadToEnd();
                textReader = textReader.Replace("T&iacute;tulo", newTitle);
                textReader = textReader.Replace("Texto del email", newContentPage);
                return textReader;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
