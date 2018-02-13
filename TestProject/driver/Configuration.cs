using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.driver
{
    public class Configuration
    {
        public static string GetEnvironmentVar(string var, string defaultValue)
        {
            return ConfigurationSettings.AppSettings[var] ?? defaultValue;
        }

        public static string ElementTimeOut => GetEnvironmentVar("ElementTimeOut", "10");

        public static string Browser => GetEnvironmentVar("Browser", "Chrome");

        public static string StartURL => GetEnvironmentVar("StartURL", "https://mail.ru");
    }
}
