using System.Configuration;

namespace SuperCommunity.Service.Configuration
{
    public class EmailProfile : ConfigurationElement
    {
        [ConfigurationProperty("email", DefaultValue = "Misha3096@yandex.ru", IsRequired = true)]
        public string Email
        {
            get
            {
                return (string)this["email"];
            }
            set
            {
                this["email"] = value;
            }
        }

        [ConfigurationProperty("password", DefaultValue = "v79b8g99498bjg", IsRequired = true)]
        public string Password
        {
            get
            {
                return (string)this["password"];
            }
            set
            {
                this["password"] = value;
            }
        }
    }

    public class EmailSettings : ConfigurationSection
    {
        [ConfigurationProperty("EmailProfile", IsRequired = true)]
        public EmailProfile EmailProfile
        {
            get
            {
                return (EmailProfile)this["EmailProfile"];
            }
            set
            {
                this["EmailProfile"] = value;
            }
        }

    }
}