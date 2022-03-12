using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace CinemaApp.Business.Utilities.Email
{
    public class EmailHelper
    {
        private string _privateEmail { get; }
        private string _privatePassword { get; }

        public EmailHelper(string privateEmail, string privatePassword)
        {
            _privateEmail = privateEmail;
            _privatePassword = privatePassword;

        }

        public bool SendEmail(string userEmail, string confirmationLink)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_privateEmail);
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = "Confirm your email";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = confirmationLink;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_privateEmail, _privatePassword);
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Port = 587;

            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                // log exception
            }
            return false;
        }
    }
}
