using System;

namespace SuperCommunity.Service.Email
{
    public class RegistrationEmail
    {
        public RegistrationEmail(string to, string userName, string password, string confirmationToken)
        {
            new EmailSender().SendMessage(to, "Registration process",
                GenerateBody(userName, password, confirmationToken));
        }

        private string GenerateBody(string userName, string password, string confirmationToken)
        {
            var uri = new Uri(
                "http://" +
                System.Web.HttpContext.Current.Request.Url.Host
                + ":"
                + System.Web.HttpContext.Current.Request.Url.Port
                );

            return "<h4>Ваш логин: "
                + userName
                + "</h4><h4>"
                + "Ваш пароль: "
                + password
                + "</h4><h4>"
                + "Для активации перейдите по ссылке:"
                + "</h4><h4>"
                + "<a href=\""
                + uri
                + "/Account/Confirmation?id="
                + confirmationToken
                + "\">Ссылка для подтверждения</a>"
                + "</h4>";
        }



    }

    
}