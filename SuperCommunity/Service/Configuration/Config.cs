using System;
using System.Configuration;

namespace SuperCommunity.Service.Configuration
{
    public class Config
    {

        internal Config() { }

        /// <summary>
        /// Группа секций в web.config
        /// </summary>
        private const string MyGroupName = "MySettings/";

        /// <summary>
        /// Секция в web.config
        /// </summary>
        private const string EmailSection = "EmailSettings";

        /// <summary>
        /// Чтение раздела конфигурации
        /// </summary>
        /// <returns>
        /// Конфигурация почты, с которой будут рассылаться уведомления
        /// </returns>
        internal static EmailSettings GetEmailSettings()
        {
            var config = (EmailSettings)ConfigurationManager.GetSection(String.Concat(MyGroupName, EmailSection));
            return config;
        }
    }
}
