using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;



namespace WebApplication1.Models.Entities
{
    // link:  stud-work.ru/index.php/c-sharp-mail-send-prostoj-primer-c-otpravka-email

    /*
       Чтобы отправлять с gmail нужны две вещи:
    1. var client = new SmtpClient("smtp.gmail.com", 587)
    2. По ссылке https://myaccount.google.com/s... заходим в настройки аккаунта и в самом низу включаем возможность использовать сторонние приложения для пользования аккаунтом.
     */

    public class EmailSender : IEmailProcessor
    {
        private string smtpServer;
        private string from;
        private string password;
        private string mailto;
        private string title;
        private string message;
        private string attachFile;

        public EmailSender(string Mailto, string Title, string Message, string Attach = null,
        string Smtp = "smtp.gmail.com", string From = "someemail.com", string Password = "")
        {
            smtpServer = Smtp;
            from = From;
            password = Password;
            mailto = Mailto;
            title = Title;
            message = Message;
            attachFile = Attach;
        }

        public bool Sent()
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = title;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
                return true;
            }
            catch (Exception e)
            {
                //throw new Exception("Mail.Send: " + e.Message);
                return false;
            }
        }
    }
}