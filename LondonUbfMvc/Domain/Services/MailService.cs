using System;
using System.Net.Mail;
using System.IO;
using LondonUbfWeb.Domain.Models;
using LondonUbfWeb.Helpers;

namespace LondonUbfWeb.Domain.Services
{
    public class MailService : IMailService
    {
        private void SendEmail(string name, string email, string responsibility, DateTime date)
        {
            string templatePath = AppHelper.TemplateAbsolutePath + @"\rota\rotatemplate.html"; 

            var message = new MailMessage();
            message.To.Add(new MailAddress(email));
            message.From = new MailAddress("ubflondon@gmail.com", "ubflondon web team");
            message.Bcc.Add(new MailAddress("Andrew Chaa <simplelifeuk@yahoo.co.uk>"));
            message.Subject = string.Format("You are a {0} on {1:dd/MM/yyyy}", responsibility, date);
            message.Priority = MailPriority.Normal;
            message.IsBodyHtml = true;

            string body = ReadTemplate(templatePath);
            body = body.Replace("[[RESPONSIBILITY]]", responsibility);
            body = body.Replace("[[FIRSTNAME]]", name.Split(' ')[0]);
            body = body.Replace("[[DESCRIPTION]]",
                string.Format("You are a {0} on {1:dd/MM/yyyy}", responsibility, date));
            message.Body = body;

            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential("ubflondon@googlemail.com", "ubflondon2008");
            //smtp.Send(message);
        }

        private string ReadTemplate(string templatePath)
        {
            using (StreamReader reader = new StreamReader(templatePath))
            {
                return reader.ReadToEnd();
            }
        }


        #region IMailService Members

        public bool SendMail(Rota rota)
        {
            try
            {
                SendEmail(rota.FullName, rota.Email, rota.Responsibility, rota.Date);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
