using System.Configuration;

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

        public static string Login => GetEnvironmentVar("Login", "login_test11");

        public static string Password => GetEnvironmentVar("Password", "pAsswOrd11");
    }
}
