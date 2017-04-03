using System.Linq;
using System.Text.RegularExpressions;

namespace SuperCommunity.Service.Entities.Account
{
    public class AccountValidationService : IService
    {
        public bool IsEmail(string email)
        {
            if (email[0].Equals('_') || !(new Regex("\\w").IsMatch(email[0].ToString())) )
            {
                return false;
            }
            if (!email.Contains("@"))
            {
                return false;
            }

            string[] emailDomen = email.Substring(email.IndexOf('@') + 1).Split('.');

            string lastDomen = emailDomen[emailDomen.Length - 1];

            string[] domens = {"ru", "by", "com", "yandex"};

            if (domens.Any(domen => domen.Equals(lastDomen)))
            {
                return true;
            }
            return false;
        }
    }
}