// Классы-адаптеры могут использовать этот клиент. 
// Клиент настроен на отправку сообщений с настройками из web.config

// Класс-адаптер может просто создать экземпляр данного клиента и
// с помощью его метода (SendMessage) отправить сообщение

// Пример:
// new EmailSender().SendMessage("куда", "Тема письма", "основной текст письма");

using System.Net;
using System.Net.Mail;
using SuperCommunity.Service.Configuration;

namespace SuperCommunity.Service.Email
{
    public class EmailSender
    {
        private SmtpClient _smtp;

        private string _from;

        private string _password;

        public EmailSender()
        {
            InitialClient();
        }

        public void SendMessage(string to, string subject, string body)
        {
            var message = new MailMessage(_from, to, subject, body) { IsBodyHtml = true };
            _smtp.Send(message);
        }

        private void InitialClient()
        {
            var config = Config.GetEmailSettings().EmailProfile;
            _from = config.Email;
            _password = config.Password;
            _smtp = new SmtpClient("smtp.yandex.ru", 25) { Credentials = new NetworkCredential(_from, _password) };
        }

    }
}