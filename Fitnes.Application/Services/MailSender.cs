using Fitnes.Application.Interfaces;
using Fitnes.Application.Models;
using System.Net;
using System.Net.Mail;

namespace Fitnes.Application.Services
{
    public class MailSender : IMailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public MailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;

            /*smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);*/

            //string passs = "cqtl fzes eaur ktik";
        }

        public Task SendMessage(string emailAddress, string message)
        {
            MailMessage mailMessage = new()
            {
                From = new MailAddress(_emailConfig.From),
                Subject = "Test",
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(new MailAddress(emailAddress));

            try
            {
                var smptclient = new SmtpClient(_emailConfig.SmtpServer)
                {
                    Port = _emailConfig.Port,
                    EnableSsl = false,
                    Credentials = new NetworkCredential(_emailConfig.From, _emailConfig.Password)
                };

                smptclient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }

            return Task.CompletedTask;
        }
    }
}